<a name='assembly'></a>
# api2

## Contents

- [ApplicationDbContext](#T-api2-Authentication-ApplicationDbContext 'api2.Authentication.ApplicationDbContext')
  - [#ctor(options)](#M-api2-Authentication-ApplicationDbContext-#ctor-Microsoft-EntityFrameworkCore-DbContextOptions{api2-Authentication-ApplicationDbContext}- 'api2.Authentication.ApplicationDbContext.#ctor(Microsoft.EntityFrameworkCore.DbContextOptions{api2.Authentication.ApplicationDbContext})')
  - [OnModelCreating(builder)](#M-api2-Authentication-ApplicationDbContext-OnModelCreating-Microsoft-EntityFrameworkCore-ModelBuilder- 'api2.Authentication.ApplicationDbContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)')
- [ApplicationDbInitializer](#T-api2-Authentication-ApplicationDbInitializer 'api2.Authentication.ApplicationDbInitializer')
  - [SeedUsers(userManager,roleManager)](#M-api2-Authentication-ApplicationDbInitializer-SeedUsers-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser},Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole}- 'api2.Authentication.ApplicationDbInitializer.SeedUsers(Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser},Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole})')
  - [generatePassword(userManager)](#M-api2-Authentication-ApplicationDbInitializer-generatePassword-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser}- 'api2.Authentication.ApplicationDbInitializer.generatePassword(Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser})')
- [ApplicationUser](#T-api2-Authentication-ApplicationUser 'api2.Authentication.ApplicationUser')
- [AuthenticateController](#T-api2-Controllers-AuthenticateController 'api2.Controllers.AuthenticateController')
  - [#ctor(userManager,roleManager,configuration,loggerFactory)](#M-api2-Controllers-AuthenticateController-#ctor-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser},Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole},Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILoggerFactory- 'api2.Controllers.AuthenticateController.#ctor(Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser},Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole},Microsoft.Extensions.Configuration.IConfiguration,Microsoft.Extensions.Logging.ILoggerFactory)')
- [ChangeEmailModel](#T-api2-Account-ChangeEmailModel 'api2.Account.ChangeEmailModel')
  - [NewEmail](#P-api2-Account-ChangeEmailModel-NewEmail 'api2.Account.ChangeEmailModel.NewEmail')
- [ChangePasswordModel](#T-api2-Account-ChangePasswordModel 'api2.Account.ChangePasswordModel')
  - [CurrentPassword](#P-api2-Account-ChangePasswordModel-CurrentPassword 'api2.Account.ChangePasswordModel.CurrentPassword')
  - [NewPassword](#P-api2-Account-ChangePasswordModel-NewPassword 'api2.Account.ChangePasswordModel.NewPassword')
- [ChangeUsername](#T-api2-Account-ChangeUsername 'api2.Account.ChangeUsername')
  - [NewUsername](#P-api2-Account-ChangeUsername-NewUsername 'api2.Account.ChangeUsername.NewUsername')
- [DatabaseToBaseController](#T-api2-Controllers-DatabaseToBaseController 'api2.Controllers.DatabaseToBaseController')
  - [#ctor()](#M-api2-Controllers-DatabaseToBaseController-#ctor-Microsoft-Extensions-Logging-ILoggerFactory- 'api2.Controllers.DatabaseToBaseController.#ctor(Microsoft.Extensions.Logging.ILoggerFactory)')
  - [_loggerFactory](#F-api2-Controllers-DatabaseToBaseController-_loggerFactory 'api2.Controllers.DatabaseToBaseController._loggerFactory')
  - [Logger](#P-api2-Controllers-DatabaseToBaseController-Logger 'api2.Controllers.DatabaseToBaseController.Logger')
- [EditAccountController](#T-api2-Controllers-EditAccountController 'api2.Controllers.EditAccountController')
  - [#ctor(userManager,roleManager,configuration)](#M-api2-Controllers-EditAccountController-#ctor-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser},Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole},Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILoggerFactory- 'api2.Controllers.EditAccountController.#ctor(Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser},Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole},Microsoft.Extensions.Configuration.IConfiguration,Microsoft.Extensions.Logging.ILoggerFactory)')
- [LoginModel](#T-api2-Authentication-LoginModel 'api2.Authentication.LoginModel')
  - [Password](#P-api2-Authentication-LoginModel-Password 'api2.Authentication.LoginModel.Password')
  - [Username](#P-api2-Authentication-LoginModel-Username 'api2.Authentication.LoginModel.Username')
- [RegisterModel](#T-api2-Authentication-RegisterModel 'api2.Authentication.RegisterModel')
  - [Email](#P-api2-Authentication-RegisterModel-Email 'api2.Authentication.RegisterModel.Email')
  - [Password](#P-api2-Authentication-RegisterModel-Password 'api2.Authentication.RegisterModel.Password')
  - [Username](#P-api2-Authentication-RegisterModel-Username 'api2.Authentication.RegisterModel.Username')
- [Response](#T-api2-Authentication-Response 'api2.Authentication.Response')
- [SuperController](#T-api2-Controllers-SuperController 'api2.Controllers.SuperController')
  - [#ctor()](#M-api2-Controllers-SuperController-#ctor-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser},Microsoft-Extensions-Logging-ILoggerFactory- 'api2.Controllers.SuperController.#ctor(Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser},Microsoft.Extensions.Logging.ILoggerFactory)')
- [UserAccount](#T-api2-Account-UserAccount 'api2.Account.UserAccount')
  - [#ctor(username,email)](#M-api2-Account-UserAccount-#ctor-System-String,System-String- 'api2.Account.UserAccount.#ctor(System.String,System.String)')
  - [Email](#P-api2-Account-UserAccount-Email 'api2.Account.UserAccount.Email')
  - [Username](#P-api2-Account-UserAccount-Username 'api2.Account.UserAccount.Username')
- [UserRoles](#T-api2-Authentication-UserRoles 'api2.Authentication.UserRoles')

<a name='T-api2-Authentication-ApplicationDbContext'></a>
## ApplicationDbContext `type`

##### Namespace

api2.Authentication

##### Summary

This class create the database context for this application

<a name='M-api2-Authentication-ApplicationDbContext-#ctor-Microsoft-EntityFrameworkCore-DbContextOptions{api2-Authentication-ApplicationDbContext}-'></a>
### #ctor(options) `constructor`

##### Summary

This method call the parent construtor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| options | [Microsoft.EntityFrameworkCore.DbContextOptions{api2.Authentication.ApplicationDbContext}](#T-Microsoft-EntityFrameworkCore-DbContextOptions{api2-Authentication-ApplicationDbContext} 'Microsoft.EntityFrameworkCore.DbContextOptions{api2.Authentication.ApplicationDbContext}') |  |

<a name='M-api2-Authentication-ApplicationDbContext-OnModelCreating-Microsoft-EntityFrameworkCore-ModelBuilder-'></a>
### OnModelCreating(builder) `method`

##### Summary

This method use builder to create the database model

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| builder | [Microsoft.EntityFrameworkCore.ModelBuilder](#T-Microsoft-EntityFrameworkCore-ModelBuilder 'Microsoft.EntityFrameworkCore.ModelBuilder') |  |

<a name='T-api2-Authentication-ApplicationDbInitializer'></a>
## ApplicationDbInitializer `type`

##### Namespace

api2.Authentication

##### Summary

This class initialize the application database

<a name='M-api2-Authentication-ApplicationDbInitializer-SeedUsers-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser},Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole}-'></a>
### SeedUsers(userManager,roleManager) `method`

##### Summary

This method create the default_super user with username "default_super" and a random generated password

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userManager | [Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser}](#T-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser} 'Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser}') | An instance of Microsoft.AspNetCore.Identity's UserManager class |
| roleManager | [Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole}](#T-Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole} 'Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole}') | An instance of Microsoft.AspNetCore.Identity's RoleManager class |

<a name='M-api2-Authentication-ApplicationDbInitializer-generatePassword-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser}-'></a>
### generatePassword(userManager) `method`

##### Summary

Genederate a random password based on UserManager's requirement

##### Returns

A password string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userManager | [Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser}](#T-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser} 'Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser}') | An instance of Microsoft.AspNetCore.Identity's UserManager class |

<a name='T-api2-Authentication-ApplicationUser'></a>
## ApplicationUser `type`

##### Namespace

api2.Authentication

##### Summary

This class is the User class of this application, which is inherited from IdentityUser class in Microsoft.AspNetCore.Identity

<a name='T-api2-Controllers-AuthenticateController'></a>
## AuthenticateController `type`

##### Namespace

api2.Controllers

<a name='M-api2-Controllers-AuthenticateController-#ctor-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser},Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole},Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILoggerFactory-'></a>
### #ctor(userManager,roleManager,configuration,loggerFactory) `constructor`

##### Summary

This is the constructor for our AuthenticateController Class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userManager | [Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser}](#T-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser} 'Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser}') | An instance of Microsoft.AspNetCore.Identity's UserManager class. |
| roleManager | [Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole}](#T-Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole} 'Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole}') | An instance of Microsoft.AspNetCore.Identity's RoleManager class. |
| configuration | [Microsoft.Extensions.Configuration.IConfiguration](#T-Microsoft-Extensions-Configuration-IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') | The configuration. |
| loggerFactory | [Microsoft.Extensions.Logging.ILoggerFactory](#T-Microsoft-Extensions-Logging-ILoggerFactory 'Microsoft.Extensions.Logging.ILoggerFactory') | An instance that creates a logger. |

<a name='T-api2-Account-ChangeEmailModel'></a>
## ChangeEmailModel `type`

##### Namespace

api2.Account

##### Summary

Component model for changing the email

<a name='P-api2-Account-ChangeEmailModel-NewEmail'></a>
### NewEmail `property`

##### Summary

This is the new email address

<a name='T-api2-Account-ChangePasswordModel'></a>
## ChangePasswordModel `type`

##### Namespace

api2.Account

##### Summary

Component model for changing the password

<a name='P-api2-Account-ChangePasswordModel-CurrentPassword'></a>
### CurrentPassword `property`

##### Summary

This is the current password

<a name='P-api2-Account-ChangePasswordModel-NewPassword'></a>
### NewPassword `property`

##### Summary

This is the new password

<a name='T-api2-Account-ChangeUsername'></a>
## ChangeUsername `type`

##### Namespace

api2.Account

##### Summary

Component model for changing the username

<a name='P-api2-Account-ChangeUsername-NewUsername'></a>
### NewUsername `property`

##### Summary

This is the new username

<a name='T-api2-Controllers-DatabaseToBaseController'></a>
## DatabaseToBaseController `type`

##### Namespace

api2.Controllers

##### Summary

This creates the DatabaseToBaseController Class.

<a name='M-api2-Controllers-DatabaseToBaseController-#ctor-Microsoft-Extensions-Logging-ILoggerFactory-'></a>
### #ctor() `constructor`

##### Summary

This is the constructor for the DatabaseToBaseController Class

##### Parameters

This constructor has no parameters.

<a name='F-api2-Controllers-DatabaseToBaseController-_loggerFactory'></a>
### _loggerFactory `constants`

##### Summary

An instance that creates logger for us.

<a name='P-api2-Controllers-DatabaseToBaseController-Logger'></a>
### Logger `property`

##### Summary

A logger that can show us messages about our project.

<a name='T-api2-Controllers-EditAccountController'></a>
## EditAccountController `type`

##### Namespace

api2.Controllers

<a name='M-api2-Controllers-EditAccountController-#ctor-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser},Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole},Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILoggerFactory-'></a>
### #ctor(userManager,roleManager,configuration) `constructor`

##### Summary

This is the constructor for our EditAccountController Class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userManager | [Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser}](#T-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser} 'Microsoft.AspNetCore.Identity.UserManager{api2.Authentication.ApplicationUser}') | An instance of Microsoft.AspNetCore.Identity's UserManager class. |
| roleManager | [Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole}](#T-Microsoft-AspNetCore-Identity-RoleManager{Microsoft-AspNetCore-Identity-IdentityRole} 'Microsoft.AspNetCore.Identity.RoleManager{Microsoft.AspNetCore.Identity.IdentityRole}') | An instance of Microsoft.AspNetCore.Identity's RoleManager class. |
| configuration | [Microsoft.Extensions.Configuration.IConfiguration](#T-Microsoft-Extensions-Configuration-IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') | The configuration. |

<a name='T-api2-Authentication-LoginModel'></a>
## LoginModel `type`

##### Namespace

api2.Authentication

##### Summary

This is the login component model

<a name='P-api2-Authentication-LoginModel-Password'></a>
### Password `property`

##### Summary

This is required password

<a name='P-api2-Authentication-LoginModel-Username'></a>
### Username `property`

##### Summary

This is required username

<a name='T-api2-Authentication-RegisterModel'></a>
## RegisterModel `type`

##### Namespace

api2.Authentication

##### Summary

This is the register component model

<a name='P-api2-Authentication-RegisterModel-Email'></a>
### Email `property`

##### Summary

This is the required email address

<a name='P-api2-Authentication-RegisterModel-Password'></a>
### Password `property`

##### Summary

This is the required password

<a name='P-api2-Authentication-RegisterModel-Username'></a>
### Username `property`

##### Summary

This is the required username

<a name='T-api2-Authentication-Response'></a>
## Response `type`

##### Namespace

api2.Authentication

##### Summary

This is the component model for api response

<a name='T-api2-Controllers-SuperController'></a>
## SuperController `type`

##### Namespace

api2.Controllers

<a name='M-api2-Controllers-SuperController-#ctor-Microsoft-AspNetCore-Identity-UserManager{api2-Authentication-ApplicationUser},Microsoft-Extensions-Logging-ILoggerFactory-'></a>
### #ctor() `constructor`

##### Summary

This is the constructor for the SuperController Class

##### Parameters

This constructor has no parameters.

<a name='T-api2-Account-UserAccount'></a>
## UserAccount `type`

##### Namespace

api2.Account

##### Summary

This class is used to manage the users name and email.

<a name='M-api2-Account-UserAccount-#ctor-System-String,System-String-'></a>
### #ctor(username,email) `constructor`

##### Summary

This initates the user account with their username and email.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The users Username. |
| email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The users email address. |

<a name='P-api2-Account-UserAccount-Email'></a>
### Email `property`

##### Summary

This is the users email address.

<a name='P-api2-Account-UserAccount-Username'></a>
### Username `property`

##### Summary

This is the users account username.

<a name='T-api2-Authentication-UserRoles'></a>
## UserRoles `type`

##### Namespace

api2.Authentication

##### Summary

This is the class of all user roles
