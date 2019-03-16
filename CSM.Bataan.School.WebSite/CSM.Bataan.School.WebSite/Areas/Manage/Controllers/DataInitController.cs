using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class DataInitController : Controller
    {
        private readonly DefaultDbContext _context;

        public DataInitController(DefaultDbContext context)
        {
            _context = context;
        }
        
        [HttpGet, Route("manage/data-init/execute")]
        public string DataInit()
        {
            //Initialize Groups
            #region Groups
            if(this._context.Groups.Count() < 1)
            {
                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19"),
                        Description = "Everyone including anonymous users.",
                        Name = "Public",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a20"),
                        Description = "All Students former and latter.",
                        Name = "Students",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a21"),
                        Description = "All currently enrolled students.",
                        Name = "Active Students",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a22"),
                        Description = "Faculty Members.",
                        Name = "Faculty",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a23"),
                        Description = "Coregroup Members",
                        Name = "Core Group",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a24"),
                        Description = "Staff",
                        Name = "Staff",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a25"),
                        Description = "Parents and Guardians",
                        Name = "Guardians",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a26"),
                        Description = "Trainee",
                        Name = "Trainees",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a27"),
                        Description = "Deserved Student Assistants.",
                        Name = "DSA",
                        Status = Status.Active
                    }
                );

                this._context.Groups.Add(
                    new Infrastructure.Data.Models.Group()
                    {
                        Id = Guid.Parse("bcc412a8-9169-489b-b579-301186947a28"),
                        Description = "Deans and Department Heads.",
                        Name = "Deans and Department Heads",
                        Status = Status.Active
                    }
                );
            }
            #endregion

            //Initialize Users
            #region Users
            if (this._context.Users.Count() < 1)
            {
                this._context.Users.Add(
                    new Infrastructure.Data.Models.User() {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f21"),
                        FirstName= "Jace",
                        LastName = "Beleren",
                        Gender = Gender.Male,
                        EmailAddress = "jbeleren@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f22"),
                        FirstName = "Liliana",
                        LastName = "Vess",
                        Gender = Gender.Female,
                        EmailAddress = "lvess@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f23"),
                        FirstName = "Chandra",
                        LastName = "Nalaar",
                        Gender = Gender.Female,
                        EmailAddress = "cnalaar@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24"),
                        FirstName = "Nissa",
                        LastName = "Revane",
                        Gender = Gender.Female,
                        EmailAddress = "nrevane@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f25"),
                        FirstName = "Elspeth",
                        LastName = "Tirel",
                        Gender = Gender.Female,
                        EmailAddress = "etirel@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26"),
                        FirstName = "Tamiyo",
                        LastName = "Moonsage",
                        Gender = Gender.Female,
                        EmailAddress = "tmoonsage@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        FirstName = "Sorin",
                        LastName = "Markov",
                        Gender = Gender.Male,
                        EmailAddress = "smarkov@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f28"),
                        FirstName = "Sarkhan",
                        LastName = "Vol",
                        Gender = Gender.Male,
                        EmailAddress = "svol@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f29"),
                        FirstName = "Garruk",
                        LastName = "Wildspeaker",
                        Gender = Gender.Male,
                        EmailAddress = "gwildspeaker@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );

                this._context.Users.Add(
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f30"),
                        FirstName = "Gideon",
                        LastName = "Jura",
                        Gender = Gender.Male,
                        EmailAddress = "gjura@mailinator.com",
                        Password = BCryptHelper.HashPassword("Accord605", BCryptHelper.GenerateSalt(9)),
                        LoginStatus = LoginStatus.Active,
                        PhoneNumber = "1234567890",
                        RegistrationCode = "ABCDEF",
                        LoginTrials = 0,
                        EnrollStatus = Status.Active
                    }
                );
            }
            #endregion

            //Initialize User Roles
            #region UserRoles
            if (this._context.UserRoles.Count() < 1)
            {
                //Jace is the Admin
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f21"),
                        Role = Role.Admin
                    }
                );

                //Liliana ////////////////////////////////////////////////////////////////////////////
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f22"),
                        Role = Role.ContentAdmin
                    }
                );

                //Chandra/////////////////////////////////////////////////////////////////////////////
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f23"),
                        Role = Role.User
                    }
                );

                //Nissa//////////////////////////////////////////////////////////////////////////////
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24"),
                        Role = Role.User
                    }
                );

                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24"),
                        Role = Role.ContentAdmin
                    }
                );

                //Elspeth////////////////////////////////////////////////////////////////////////////
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f25"),
                        Role = Role.User
                    }
                );

                //Tamiyo/////////////////////////////////////////////////////////////////////////////
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26"),
                        Role = Role.User
                    }
                );

                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26"),
                        Role = Role.ContentAdmin
                    }
                );

                //Sorin
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        Role = Role.User
                    }
                );

                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        Role = Role.ContentAdmin
                    }
                );

                //Sarkhan
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f28"),
                        Role = Role.User
                    }
                );

                //Garruk
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f29"),
                        Role = Role.User
                    }
                );

                //Gideon
                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f30"),
                        Role = Role.ContentAdmin
                    }
                );

                this._context.UserRoles.Add(
                    new Infrastructure.Data.Models.UserRole()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f30"),
                        Role = Role.User
                    }
                );
            }
            #endregion

            //Initialize User Groups
            #region UserGroups
            if (this._context.UserGroups.Count() < 1)
            {
                #region Public Group
                //Everyone is a member of the Public Group
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f21"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f22"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f23"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f25"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f28"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f29"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f30"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                    }
                );
                #endregion

                #region Students
                //
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f23"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a20")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a20")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f25"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a20")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a20")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a20")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f28"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a20")
                    }
                );
                #endregion

                #region ActiveStudents
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f23"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a21")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a21")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a21")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f28"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a21")
                    }
                );
                #endregion

                #region Faculty
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f22"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a22")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a22")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f25"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a22")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f30"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a22")
                    }
                );
                #endregion

                #region CoreGroup
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f21"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a23")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f22"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a23")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a23")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f29"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a23")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f30"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a23")
                    }
                );
                #endregion

                #region Staff
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f21"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a24")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f23"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a24")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f25"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a24")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f30"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a24")
                    }
                );
                #endregion

                #region Guardians
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f28"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a25")
                    }
                );
                #endregion

                #region Trainees
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a26")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f29"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a26")
                    }
                );
                #endregion

                #region DSA
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a27")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a27")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f28"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a27")
                    }
                );
                #endregion

                #region DeansAndDepartmentHeads
                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f21"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a28")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f22"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a28")
                    }
                );

                this._context.UserGroups.Add(
                    new Infrastructure.Data.Models.UserGroup()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f29"),
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a28")
                    }
                );
                #endregion
            }
            #endregion

            //Initialize News
            if(this._context.News.Count() < 1)
            {
                //public news
                this._context.News.Add(
                    new Infrastructure.Data.Models.NewsItem()
                    {
                        Id = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf210"),
                        Description = "CSM Bataan launches its official website.",
                        Title = "CSM Bataan WebSite Launched",
                        Content = "<h2>CSM Bataan has recentyle launched its official website.<h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019"),
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f21")
                    }
                );

                this._context.NewsGroups.Add(
                    new Infrastructure.Data.Models.NewsGroup()
                    {
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19"),
                        NewsItemId = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf210")
                    }
                );

                //Faculty news
                this._context.News.Add(
                    new Infrastructure.Data.Models.NewsItem()
                    {
                        Id = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf211"),
                        Description = "Boys and Girls, this is your new website",
                        Title = "Welcome Faculty members to the CSM Bataan WebSite ",
                        Content = "<h2>Welcome Faculty members to the CSM Bataan WebSite.<h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019"),
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f22")
                    }
                );

                this._context.NewsGroups.Add(
                    new Infrastructure.Data.Models.NewsGroup()
                    {
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a22"),
                        NewsItemId = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf211")
                    }
                );

                //Active Student news
                this._context.News.Add(
                    new Infrastructure.Data.Models.NewsItem()
                    {
                        Id = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf212"),
                        Description = "Boys and Girls, this is your new website",
                        Title = "Welcome Active Students to the CSM Bataan WebSite ",
                        Content = "<h2>Welcome Active Students to the CSM Bataan WebSite.<h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019"),
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26")
                    }
                );

                this._context.NewsGroups.Add(
                    new Infrastructure.Data.Models.NewsGroup()
                    {
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a21"),
                        NewsItemId = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf212")
                    }
                );

                //Student news
                this._context.News.Add(
                    new Infrastructure.Data.Models.NewsItem()
                    {
                        Id = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf213"),
                        Description = "Boys and Girls, this is your new website",
                        Title = "Welcome students to the CSM Bataan WebSite ",
                        Content = "<h2>Welcome students to the CSM Bataan WebSite.<h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019"),
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24")
                    }
                );

                this._context.NewsGroups.Add(
                    new Infrastructure.Data.Models.NewsGroup()
                    {
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a20"),
                        NewsItemId = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf213")
                    }
                );

                //CoreGroup news
                this._context.News.Add(
                    new Infrastructure.Data.Models.NewsItem()
                    {
                        Id = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf214"),
                        Description = "Boys and Girls, this is your new website",
                        Title = "Welcome CoreGroup Members to the CSM Bataan WebSite ",
                        Content = "<h2>Welcome CoreGroup Members to the CSM Bataan WebSite.<h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019"),
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f30")
                    }
                );

                this._context.NewsGroups.Add(
                    new Infrastructure.Data.Models.NewsGroup()
                    {
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a23"),
                        NewsItemId = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf214")
                    }
                );

                //DSA news
                this._context.News.Add(
                    new Infrastructure.Data.Models.NewsItem()
                    {
                        Id = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf215"),
                        Description = "Boys and Girls, this is your new website",
                        Title = "Welcome DSAs to the CSM Bataan WebSite ",
                        Content = "<h2>Welcome DSAs Members to the CSM Bataan WebSite.<h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019"),
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f26")
                    }
                );

                this._context.NewsGroups.Add(
                    new Infrastructure.Data.Models.NewsGroup()
                    {
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a27"),
                        NewsItemId = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf215")
                    }
                );
            }



            this._context.SaveChanges();
            return "OK";
        }
    }
}