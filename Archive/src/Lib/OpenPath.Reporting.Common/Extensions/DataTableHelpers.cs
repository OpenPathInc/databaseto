using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OpenPath.Reporting.Common.Extensions
{

    /// <summary>
    /// Custom extensions to the <see cref="DataTable"/> class.
    /// </summary>
    public static class DataTableHelpers
    {
        /// <summary>
        /// Creates and populates a <see cref="DataTable"/> with the properties from the underlying type
        /// of the items in the specified list. The DataTable's columns are created in the order of the properties
        /// in the unerlying type.
        /// </summary>
        /// <remarks>
        /// When this method is used to create a DataTable for use as a Table Valued Parameter (e.g. by using
        /// the Dapper SqlMapper extension method) then you should make sure that the order of the DataTable's columns match
        /// the order of the fields in the underlying SQL Type to ensure that the correct properties is passed into the correct columns.
        /// </remarks>
        /// <typeparam name="T">The <see cref="Type"/> of the entities in the list.</typeparam>
        /// <param name="list">The entities to add into the data table.</param>
        /// <returns>A <see cref="DataTable"/> containing the entities.</returns>
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            if (list == null)
            {
                return null;
            }

            var type = typeof(T);
            var properties = type.GetProperties();

            var dataTable = new DataTable();

            if (properties.Length == 0)
            {
                dataTable.Columns.Add(new DataColumn("Value", type));
            }
            else
            {
                foreach (var info in properties)
                {
                    var dataType = info.PropertyType.IsEnum ?
                        Enum.GetUnderlyingType(info.PropertyType)
                        : Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;

                    // Skip properties that are collections of stuff (e.g. lists)
                    if (info.PropertyType.GetInterface(typeof(ICollection<>).FullName) != null)
                    {
                        continue;
                    }

                    dataTable.Columns.Add(new DataColumn(info.Name, dataType));
                }
            }

            var entityType = list.First().GetType();
            foreach (var entity in list)
            {
                var values = new object[dataTable.Columns.Count];
                for (var i = 0; i < dataTable.Columns.Count; i++)
                {
                    var typeProp = entityType.GetProperty(dataTable.Columns[i].ColumnName);

                    values[i] = typeProp != null ? typeProp.GetValue(entity) : entity;
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        /// <summary>
        /// Wrapper for <see cref="CreateDataTable{T}(IEnumerable{T})"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the entity.</typeparam>
        /// <param name="entity">A single instance of the entity.</param>
        public static DataTable CreateDataTable<T>(T entity)
        {
            var list = new List<T>(1)
            {
                entity
            };

            return CreateDataTable<T>(list);
        }
    }

}
