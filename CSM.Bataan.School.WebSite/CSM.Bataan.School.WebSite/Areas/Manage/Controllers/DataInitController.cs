using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
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
            if (this._context.Groups.Count() < 1)
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
                    new Infrastructure.Data.Models.User()
                    {
                        Id = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f21"),
                        FirstName = "Jace",
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
            if (this._context.News.Count() < 1)
            {
                //public news
                this._context.News.Add(
                    new Infrastructure.Data.Models.NewsItem()
                    {
                        Id = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf209"),
                        Description = "CSM Bataan - School Feature",
                        Title = "CSM Bataan at a Glance",
                        Content = "<h2>Feature article for CSM Bataan school<h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019"),
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f24")
                    }
                );

                this._context.NewsGroups.Add(
                    new Infrastructure.Data.Models.NewsGroup()
                    {
                        GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19"),
                        NewsItemId = Guid.Parse("8d8a4146-86dd-4cd9-a2f4-e65d6f0bf209")
                    }
                );

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

            //Initialize Certifications
            if (this._context.Certifications.Count() < 1)
            {
                this._context.Certifications.Add(
                    new Certification()
                    {
                        Id = Guid.Parse("a774bd51-07d4-4bc6-9f14-230811e0c801"),
                        Description = "Get your Microsoft Office Specialist - Word certification from College of Subic Montessori - Authorized Certiport Testing Center.",
                        StartDate = DateTime.UtcNow.AddMonths(3).AddHours(8),
                        EndDate = DateTime.UtcNow.AddMonths(3).AddHours(13),
                        IsPublished = true,
                        Limit = 20,
                        PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                        Title = "Microsoft Office Specialist - Word",
                        Type = CertType.Assessment
                    }
                );

                this._context.Certifications.Add(
                    new Certification()
                    {
                        Id = Guid.Parse("a774bd51-07d4-4bc6-9f14-230811e0c802"),
                        Description = "Get your Microsoft Office Specialist - Excel certification from College of Subic Montessori - Authorized Certiport Testing Center.",
                        StartDate = DateTime.UtcNow.AddMonths(3).AddDays(5).AddHours(8),
                        EndDate = DateTime.UtcNow.AddMonths(3).AddDays(5).AddHours(13),
                        IsPublished = true,
                        Limit = 20,
                        PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(6),
                        Title = "Microsoft Office Specialist - Excel",
                        Type = CertType.Assessment
                    }
                );

                this._context.CertificationRegistrations.Add(
                    new CertificationRegistration()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        CertificationId = Guid.Parse("a774bd51-07d4-4bc6-9f14-230811e0c801")
                    }
                );

                this._context.CertificationRegistrations.Add(
                    new CertificationRegistration()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f29"),
                        CertificationId = Guid.Parse("a774bd51-07d4-4bc6-9f14-230811e0c801")
                    }
                );

                this._context.CertificationRegistrations.Add(
                    new CertificationRegistration()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f27"),
                        CertificationId = Guid.Parse("a774bd51-07d4-4bc6-9f14-230811e0c802")
                    }
                );

                this._context.CertificationRegistrations.Add(
                    new CertificationRegistration()
                    {
                        UserId = Guid.Parse("ba9054b6-225a-410c-b934-97844c778f29"),
                        CertificationId = Guid.Parse("a774bd51-07d4-4bc6-9f14-230811e0c802")
                    }
                );
            }
            //Initialize FAQS
            if (this._context.Faqs.Count() < 1)
            {
                //public faqs 1
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("c77c4837-a204-431d-9002-18a32448ec41"),
                        Description =
                        "<ul><li>1. CALL(047) 633-5531 or Email csm.bataan888@yahoo.com<li>" +
                        "<li>2. For New Students Submit admission requirements at the Register's Office and proceed to advising of subjects OIC-Principal - Basic Education Dept. Dean/OIC - College Head - Higher Education Dept. For OLD Student : Duly Signed Clearance<li> " +
                        "<li>3. For NEW/TRANSFEREES proceed to Guidance and Counseling Office for the Schedule of Assessment Exam, proceed to designated room for the measurement of uniform, For OLD Students proceed to Step 5<li>" +
                        "<li>4. proceed to Step 5  <li>" +
                        "<li>5. Proceed to Finance Office for the assessment of Fees<li> " +
                        "<li>6. Payment of assesed Tuition and other fees<li> " +
                        "<li>7. You are now officially ENROLLED (SPENDS A DAY AS A MONTESSORIAN!)</li></ul>",
                        Question = "How to inquire ",
                        Answer = "CSM Bataan Faqs - Inquire",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 2
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("c77c4837-a204-431d-9002-18a32448ec42"),
                        Description = "CSM is College of Subic Montessori, INC",
                        Question = "What is CSM",
                        Answer = "CSM Bataan Faqs - CSM",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 3
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("36d5d91d-e9a4-49b0-8465-87a88db3b82a"),
                        Description = " CSM is located at National Road Sta. Isabel,Dinalupihan, Bataan. In Front of Brgy. Sta.Isabel Court.",
                        Question = "Where is CSM located",
                        Answer = "CSM Bataan Faqs - CSM Location",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 4
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("069481b1-1251-4ecd-beea-ce63407e5f39"),
                        Description = 
                        "Under Basic Education Curriculum:" +
                        "<p>CASA Department</p> " +
                        "<ul>" +
                        "<li>Toddler 		2-3 yrs. old </li>" +
                        "<li>Junior Casa	3-4 yrs. old </li>" +
                        "<li>Senior Casa	4-5 yrs. old </li>" +
                        "<li>Advanced Casa	5-6 yrs. old </li>" +
                        "</ul>" +
                        "<p>Primary Department</p> " +
                        "<ul>" +
                        "<li>Grade One,Grade Two</li>" +
                        "<li> Grade Three</li>" +
                        "</ul>" +
                        "<p>Middle School Department</p>" +
                        "<ul>" +
                        "<li>Grade Four<li>" +
                        "<li>Grade Five</li>" +
                        "<li>Grade Six</li>" +
                        "</ul>" +
                        "<p>Junior High School Department</p>" +
                        "<ul>" +
                        "<li>Grade Seven</li>" +
                        "<li>Grade Eight</li> " +
                        "<li> Grade Nine</li>" +
                        "<li> Grade Ten</li>" +
                        "<ul>" +
                        "<p>Senior High School Department</p>" +
                        "<ul>" +
                        "<li> Grade Eleven</li>" +
                        "<li>Grade Twelve</li>" +
                        "<ul>" +
                        "<p>Under Higher Education Department:<p> " +
                        "<ul>" +
                        "<li>Bachelor of Science in Business Administration<li>" +
                        "<li>Major in the following:</li> " +
                        "<li> Human Resource Development Management</li>" +
                        "<li> Financial Management</li>" +
                        "<li>Operations Management</li>" +
                        "<li> Marketing Management</li> " +
                        "<li> Bachelor of Science in Criminology</li>" +
                        "<li>Bachelor of Science in Customs Administration</li>" +
                        "<li>Bachelor of Science in Tourism Management</li>" +
                        "<li>Bachelor of Science in Information Systems</li>" +
                        "<li> Associate in Computer Technology</li>" +
                        "<li> Hotel and Restaurant Services</li>" +
                        "<ul>" +
                        "<p>With the following Competencies:</p> " +
                        "<ul>" +
                        "<li>Food and Beverage Services NC II </li>" +
                        "<li> Front Office Services NC II </li>" +
                        "<li>Housekeeping NC II </li>" +
                        "<li>Computer Systems Servicing NC II </li>" +
                        "<li>Visual Graphic Design NC II </li></ul>",
                        Question = "What programs does CSM offers",
                        Answer = "CSM Bataan Faqs - CSM offers",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );



                //public faqs 5
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("97cff192-be4f-4394-ad8e-0bc5676d643c"),
                        Description =
                        "<ul>" +
                        "<li>Complete Uniform</li>" +
                        "<li>I.D Student</li>" +
                        "<li>Short hair no color</li> " +
                        "<li>No accessories</li>" +
                        "<li>Gadget is ban in school</li>" +
                        "</ul>",
                        Question = "What are the rules of CSM",
                        Answer = "CSM Bataan Faqs - Illegal Items",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 6
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("3d860447-7948-4e93-b8a1-9bec264722dd"),
                        Description = 
                        "<ul>" +
                        "<li> Applicants can visit our Admission Office from Monday to Saturday </li>" +
                        "<li> 8am-5pm. Bring admission/ enrollment requirements </li>",
                        Question = "How can a student apply for admission",
                        Answer = "CSM Bataan Faqs - apply for admission",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 7
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("a6444523-2ba9-4fdc-b76c-96c6338bdb70"),
                        Description = "CSM accepts transferees on a case to case basis.",
                        Question = "Does CSM accept transferees",
                        Answer = "CSM Bataan Faqs - accept tranferees",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );


                //public faqs 8
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("28520b43-07d8-45dd-b984-28978f85c87b"),
                        Description =
                        "<ul>" +
                        "<li>Long Brown Envelope</li>" +
                        "<li>2x2 Pictures (1pc.) 1x1 Picture (2pcs.)</li>" +
                        "<li>Medical Certificate</li>" +
                        "<li>Photocopy of PSA Birth Certificate.</li>" +
                        "</ul>",

                        Question = "What are the requirements for admission/ enrollment for CASA Student (New Student)",
                        Answer = "CSM Bataan Faqs - admission/ enrollment for CASA Student (New Student)",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 9
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("a9c85c69-3789-4444-9e96-44c3930190cb"),
                        Description = "Duly Signed Clearance",
                        Question = "What are the requirements for admission/ enrollment for CASA Student (Old Student)?",
                        Answer = "CSM Bataan Faqs - admission/ enrollment for CASA Student (Old Student)",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 10
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("4443bc5c-9715-4759-a642-42c0f9bf5610"),
                        Description =
                        "<ul>" +
                        "<li>Long Brown Envelope</li>" +
                        "<li>2x2 Pictures (1pc.) 1x1 Picture (2pcs.)</li>" +
                        "<li>Medical Certificate</li>" +
                        "<li>Photocopy of PSA Birth Certificate</li>" +
                        "<li>Form 138/ Form 137</li>" +
                        "<li>Good Moral Certificate</li>" +
                        "</ul>",

                        Question = "What are the requirements for admission/ enrollment for Grade School,Junior High School and Senior High School Student (New Student)?",
                        Answer = "CSM Bataan Faqs - admission/ enrollment for Grade School, Junior High School and Senior High School Student (New Student)",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 11
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("89117bb3-46a0-42ba-8cee-40ffb1dc01b2"),
                        Description = "Duly Signed Clearance",
                        Question = "What are the requirements for admission/ enrollment for Grade School, Junior High School and Senior High School Student (Old Student)",
                        Answer = "CSM Bataan Faqs - admission/ enrollment for Grade School, Junior High School and Senior High School Student (Old Student)",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 12
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("0f243c0c-5fbc-4b16-8a30-4355060f637a"),
                        Description =
                        "<ul>" +
                        "<li>Long Brown Envelope</li>" +
                        "<li>Long Plastic Envelope</li>" +
                        "<li>2x2 Pictures (1pc.) 1x1 Picture (2pcs.)</li>" +
                        "<li>Photocopy of PSA Birth Certificate</li>" +
                        "<li>Form 138/ Form 137</li>" +
                        "<li>Good Moral Certificate</li>" +
                        "<li>Photocopy of Diploma</li>",

                        Question = "What are the requirements for admission/ enrollment for College Student (New Student/ Freshman)?",
                        Answer = " admission/ enrollment for College Student (New Student/ Freshman)",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 13
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("50a04b3c-f4ff-4a9b-a7e5-396e97ea55ed"),
                        Description =
                        "<ul>" +
                        "<li>Long Brown Envelope</li>" +
                        "<li>Long Plastic Envelope</li>" +
                        "<li>2x2 Pictures (1pc.) 1x1 Picture (2pcs.)</li>" +
                        "<li>Photocopy of PSA Birth Certificate</li>" +
                        "<li>Honorable Dismissal</li>" +
                        "<li>Certificate of Grades for Evaluation</li>" +
                        "<li>Transcript of Records (if available)</li>" +
                        "</ul>",

                        Question = "What are the requirements for admission/ enrollment for College Student (Transferee)",
                        Answer = " admission/ enrollment for College Student (Transferee)",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 14
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("b47032ac-ae42-4238-8ea6-942dd170d636"),
                        Description = "Duly Signed Clearance",
                        Question = "What are the requirements for admission/ enrollment for College Student (Old Student)",
                        Answer = "admission/ enrollment for College Student (Old Student)",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 15
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("5883f42f-65fc-4030-9f0d-4d0f86be3f55"),
                        Description = "CSM is an Authorized Testing Center for Microsoft Office Specialist and Microsoft Technology Associate.",
                        Question = "What other certification program does CSM offers",
                        Answer = "other certification program does CSM offers",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );

                //public faqs 16
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("c571709e-e086-4dce-b1d1-b9d6e822612d"),
                        Description =
                        "<ul>" +
                        "<li>CSM offers scholarship programs in Computer Systems Servicing NC II</li>" +
                        "<li>Front Office Services NC II</li>" +
                        "<li>Food and Beverage Services NC II</li>" +
                        "<li>Housekeeping NC II </li>" +
                        "<li>It is a free training under Training for Work Scholarship Program by Technical Education and Skills Development Authority (TESDA).</li>" +
                        "</ul>",

                        Question = "What TESDA Scholarship do CSM offers",
                        Answer = "TESDA Scholarship do CSM offers",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );


                //public faqs 17
                this._context.Faqs.Add(
                    new Infrastructure.Data.Models.Faq()
                    {
                        Id = Guid.Parse("4a2b0a6d-84d8-4b79-b53b-3a76dfbec134"),
                        Description = "Various scholarships and service grants are available to deserving students.",
                        Question = "What scholarships and grants are available to students under Junior High and Senior High Level",
                        Answer = "scholarships and grants are available to students under Junior High and Senior High Level",
                        IsPublished = true,
                        PostExpiry = DateTime.Parse("December 30 2019")

                    }
                );
                //public faqs 18
                this._context.Faqs.Add(
                   new Infrastructure.Data.Models.Faq()
                   {
                       Id = Guid.Parse("f5319415-4005-4fd6-b543-b49a0f5c0ed5"),
                       Description =
                       "<ul>" +
                       "<li>For CASA to Senior Highschool</li>" +
                       "<li>1. Accountancy in business management </li>" +
                       "<li>2. TVL(Technical Vocation Livelihood), ICT (Information & Communication Technology), HE (Home Economics)</li>" +
                       "<li>3. HUMMS (Humanities & Social Science)<hr> GAS (General Academic Strand) </li>" +
                       "<li>4. STEM (Sciences Technology,Enginnering & Mathematics</li>" +
                       "</ul>",

                       Question = "What are the requirements for STRAND/TRACK offered" + "(For CASA to Senior Highschool)",
                       Answer = "CSM Bataan Faqs - STRAND/TRACK (CASA & SHS)",
                       IsPublished = true,
                       PostExpiry = DateTime.Parse("December 30 2019")

                   }
               );

                //public faqs 19
                this._context.Faqs.Add(
                   new Infrastructure.Data.Models.Faq()
                   {
                       Id = Guid.Parse("1a1438e3-6e26-45e5-9d87-855340ebda96"),
                       Description =
                       "<ul>" +
                       "<li>COMPUTER SYSTEMS SERVICING NC II</li>" +
                       "<li>FRONT OFFICE SERVICES NC II</li>" +
                       "<li>FOOD & BEVERAGES SERVICES NC II</li> " +
                       "<li>HOUSEKEEPING NC.</li>" +
                       "</ul>",

                       Question = "What are the TRAINING & ASSESSMENT CENTER of CSM ?",
                       Answer = "CSM Bataan Faqs - TRAINING & ASSESSMENT CENTER",
                       IsPublished = true,
                       PostExpiry = DateTime.Parse("December 30 2019")

                   }
               );
                //public faqs 20
                this._context.Faqs.Add(
                 new Infrastructure.Data.Models.Faq()
                 {
                     Id = Guid.Parse("f20efdc0-33ba-438c-877a-bd8c989385d4"),
                     Description =
                     "<ul>" +
                     "<li>For CASA to Senior HighSchool</li>" +
                     "<li>1. Duly signed Clearance</li>" +
                     "<li>2.Report Card</li>" +
                     "</ul>",

                     Question = "What are the requirements for OLD STUDENT " + "(For CASA to Senior HighSchool )",
                     Answer = "CSM Bataan Faqs - Requirement for OLD STUDENT ",
                     IsPublished = true,
                     PostExpiry = DateTime.Parse("December 30 2019")

                 }
             );


                //public faqs 21
                this._context.Faqs.Add(
                new Infrastructure.Data.Models.Faq()
                {
                    Id = Guid.Parse("c71a4d05-c4e3-4221-886d-48119c86417d"),
                    Description =
                    "<ul>" +
                    "<li>For CASA to Senior HighSchool</li> " +
                    "<li>1. High School Report Card (F138 / F137A)</li> " +
                    "<li>2.Diploma (Photocopy)</li>" +
                    "<li>3.Good Moral Character Certification</li> " +
                    "<li>4.NSO Birth Certificate (Photocopy) </li>" +
                    "<li>5.Two(2)pcs. Long Brown Envelope with Plastic Cover</li>" +
                    "<li>6.One(1)pc. 1x1 picture and 1 pcs. 2x2 picture </li>" +
                    "<li>7. Medical Certificate 8. Must undergo an Assessment Examination.</li>" +
                    "</ul> ",

                    Question = "What are the requirements for NEW STUDENT  " + "(For CASA to Senior HighSchool )",
                    Answer = "CSM Bataan Faqs - Requirement for NEW STUDENT ",
                    IsPublished = true,
                    PostExpiry = DateTime.Parse("December 30 2019")

                }
            );

                //public faqs 22
                this._context.Faqs.Add(
                new Infrastructure.Data.Models.Faq()
                {
                    Id = Guid.Parse("2446aeba-3887-4b37-b0d7-b9ca6a8d06e5"),
                    Description =
                    "<ul>" +
                    "<li>For CASA to Senior HighSchool </li>" +
                    "<li>1.Official Transcript of Records or Certification of Grades</li>" +
                    "<li>2.Good Moral Character Certification</li>" +
                    "<li>3.NSO Birth Certificate ( Photocopy)</li> " +
                    "<li>4.Recommendation Form </li>" +
                    "<li>5.Two (2)pcs. Long Brown Envelope with Plastic Cover</li>" +
                    "<li>6.Medical Certificate</li>" +
                    "<li>7.Must undergo an Assessment Examinantion.</li>" +
                    "</ul> ",

                    Question = "What are the requirements for TRANSFEREES",
                    Answer = "CSM Bataan Faqs - Requirement for TRANSFEREES ",
                    IsPublished = true,
                    PostExpiry = DateTime.Parse("December 30 2019")

                }
            );

                //public faqs 23
                this._context.Faqs.Add(
              new Infrastructure.Data.Models.Faq()
              {
                  Id = Guid.Parse("05246a02-f147-4b9b-9a4a-a8da369f8117"),
                  Description =
                  "<ul>" +
                  "<li>PRE-ELEMENTARY TODDLER - 2-3 yrs. old </li>" +
                  "<li>JUNIOR CASA - 3-4yrs. old</li>" +
                  "<li>SENIOR CASA - 4-5yrs.old</li>" +
                  "<li>ADVANCED CASA - 5-6yrs.old </li>" +
                  "</ul>" +
                  "<ul>" +
                  "<li>PRIMARY SCHOOL <li>" +
                  "<li> Grade One</li>" +
                  "<li> Grade Two</li>" +
                  "<li> Grade Three</li>" +
                  "<li>MIDDLE SCHOOL<li>" +
                  "<li>Grade Four<li>" +
                  "<li> Grade Five<li>" +
                  "<li> GRADE Six<li>" +
                  "<li>JUNIOR HIGH SCHOOL</li>" + "" +
                  "<li> GRADE Seven</li>" +
                  "<li> GRADE Eight</li>" +
                  "<li> GRADE Nine</li>" +
                  "<li> GRADE Ten</li>" +
                  "<li>SENIOR HIGH SCHOOL</li>" +
                  "<li> GRADE Eleven</li>" +
                  "<li> GRADE Twelve</li>",

                  Question = "What are the BASIC EDUCATION PROGRAMS ",
                  Answer = "CSM Bataan Faqs - BASIC EDUCATION PROGRAMS",
                  IsPublished = true,
                  PostExpiry = DateTime.Parse("December 30 2019")

              }
            );
            }


                //Initialize SchoolFacility
                if (this._context.SchoolFacilities.Count() < 1)
                {
                    //Initialize SchoolFacility 1
                    this._context.SchoolFacilities.Add(
                        new SchoolFacility()
                        {
                            Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                            Description = "The students use the VGD room for computer subjects ",
                            Content = "The students use the VGD room for computer subjects like photo and logo design. It is also used for assessments. Lastly, BSIS students use it for their classes.",
                            IsPublished = true,
                            PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                            Title = "Visual, Graphic, Design Room",
                        }
                    );


                    //Initialize SchoolFacility  2
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("e5bbc1c9-d90c-4ec1-a845-7594e2d81f8d"),
                           Description = "CSM also have  a library for the students.. ",
                           Content = "CSM also have  a library for the students want to search about thier lecture,  sometimes library room use for meeting.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Library Room",
                       }
                   );

                    //Initialize SchoolFacility 3
                    this._context.SchoolFacilities.Add(
                               new SchoolFacility()
                               {
                                   Id = Guid.Parse("39648aa6-f2d0-4b8d-a265-d6f66d80ae97"),
                                   Description = "....",
                                   Content = "",
                                   IsPublished = true,
                                   PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                                   Title = "CSD room",
                               }
                           );
                    //Initialize SchoolFacility 4
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("f5265303-4558-4dfa-bb03-e60f2050feb3"),
                           Description = "School canteen,  is very convenient..",
                           Content = "School canteen,  is very convenient. The middle and highschool students can put money on their  ID so when they want to buy food in the canteen they can just use their school ID to pay for it",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Canteen",
                       }
                   );
                    //Initialize SchoolFacility 5
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("f12faa71-3d5a-434b-afbd-746c323211d5"),
                           Description = "The registrar room is an office..",
                           Content = "The registrar room is an office staffed with friendly employees who can help you with items such as enrollment requirements," +
                           " what subjects are available, what course is open, how to get a diploma, a transcript of what a student studied and their grades," +
                           " and how a student get a special exams for college.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Registrar Office",
                       }
                   );
                    //Initialize SchoolFacility 6
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("0ba4b1c2-1371-4b31-899a-6799bd3511e4"),
                           Description = "Our gymnasium is a mult-purpose hall..",
                           Content = "Our gymnasium is a mult-purpose hall that is used for aquitance parties, and various programs that require a large area. It is also used for physical activities like dancing, basketball and volleyball. The criminolgy students use it for their formations and physical activities.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Gymnasium",
                       }

                   );
                    //Initialize SchoolFacility 7
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("76bd5a75-3314-4d42-8e39-b7bcdd6f35e9"),
                           Description = "Our school also features a well-equipped clinic...",
                           Content = "Our school also features a well-equipped clinic for students who are ill or need to rest. A professional nurse works there to provide medical treatment to those in need of first-aid.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "School Clinic",
                       }
                   );
                    //Initialize SchoolFacility 8
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("23d5de16-b791-4ec9-bdae-90740fa923bd"),
                           Description = "There is an accounting office called Window 1 & Window 2...",
                           Content = "There is an accounting office called Window 1." +
                           " There a student can get information about what they owe for things like school uniforms, paper, notebooks, tuition, uniforms and other fees. " +
                           "Window 2 is the cashier's office where the payment is actually made.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Window 1 Office & Window 2 Office",
                       }
                   );
                    //Initialize SchoolFacility 9
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("0534aa2c-4b8b-4770-a6cb-ab12ca40f535"),
                           Description = "In the guidance office students can receive counseling about problems they're having...",
                           Content = "In the guidance office students can receive counseling about problems they're having. " +
                           "They can also obtain guidance about what career options are available to them.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Guidance Office",
                       }
                   );
                    //Initialize SchoolFacility 10
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("013525f8-6204-45fa-824b-80c007f79b1f"),
                           Description = "An area equipped with all the needed tools..",
                           Content = "An area equipped with all the needed tools and materials needed for smooth and efficient  FOOD AND BEVERAGE TRAINING.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Front office",
                       }
                   );
                    //Initialize SchoolFacility 11
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("4ef0e59d-41d5-4005-80d5-204987688699"),
                           Description = " The school also provides comfort rooms ...",
                           Content = " The school also provides comfort rooms with comfortable toilets students can use at their convenience. The men's comfort rooms also features an urinal that many male like.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Male and female comfort rooms",
                       }
                   );

                    //Initialize SchoolFacility 12
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("a8a5fdf4-5c59-48b4-a625-7b1524689f0b"),
                           Description = "Marketing Office is one of the busy office in our campus...",
                           Content = "Marketing Office is one of the busy office in our campus. We ensure that every client who comes to our school will received all the information they need to know with regards to our humble institution." +
                           "Our marketing staffs are always busy the whole year round conducting a career orientations to every schools from basic education upto high school for proper endorsement of our school." +
                           "We also keep on updating our clients with our events, class suspension, announcement, etc.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Marketing Office",
                       }
                   );
                    //Initialize SchoolFacility 12
                    this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("013752a0-3163-46a1-ba37-72af38460eb9"),
                           Description = "Our school parking area",
                           Content = "Available parking area for parents, visitors and employees",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Parking Area",
                       }
                   );

                }







            //Initialize Alumni Profile Entries
            if (this._context.AlumniProfiles.Count() < 1)
            {
                //Alumni Profile Entries 1
                this._context.AlumniProfiles.Add(
                  new AlumniProfile()
                  {
                      Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                      Description =
                      "<ul>" +
                      "<li>Name: Erza Alfonzo</li>" +
                      "<li>Course: Bachelor of Science Criminology</li>" +
                      "<li>Gender: Female</li>" +
                      "<li>Email Address: erza.alfonso12@gmail.com</li>" +
                      "<li>Latest work:Rescuer</li>" +
                      "<li>Department: Municipal Disaster Risk Reduction and Management Office (MDRRMO)</li>" +
                      "</ul>",
                      Position = "Admin Aide IV",
                      Location = "Burgos-Soliman, Hermosa, Bataan",
                      IsPublished = true,
                      Company = "Municipality of Hermosa - LGU Hermosa",
                  }

                );

                //Alumni Profile Entries 2
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Darlene Shane Santos</li>" +
                     "<li>Course: Bachelor of Science Custom Administration</li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: dpserrano.toyota@gmail.com</li>" +
                     "<li>Latest work: Sales</li>" +
                     "<li>toyota company</li>" +
                     "</ul>",
                     Position = "Marketing Professional",
                     Location = "balanga bataan",
                     IsPublished = true,
                     Company = "Toyota Bataan Inc.",
                 }

               );

                //Alumni Profile Entries 3
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Almira S. Banzon</li>" +
                     "<li>Course: Bachelor of Science Information Systems</li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: almirabanzon1902@gmail.com</ li>" +
                     "<li>Latest work:CSM Associate Registrar</li>" +
                     "</ul>",
                     Position = "Associate Registrar",
                     Location = "Sta. Isabel, Dinalupihan, Bataan",
                     IsPublished = true,
                     Company = "College of Subic Montessori Inc.",
                 }

               );


                //Alumni Profile Entries 4
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: John Paul C Pamintuan</li>" +
                     "<li>Course: Bachelor of Science Business Administration(Marketing Management)</li>" +
                     "<li>Gender: Male</li>" +
                     "<li>Email Address: John Paul C Pamintuan</li>" +
                     "<li>Latest work:Professional Medical Representative</ li>" +
                     "</ul>",
                     Position = "territory Manager",
                     Location = "4th Flr Jafer Building West Ave. Quezon City",
                     IsPublished = true,
                     Company = "Kaufmann Pharma Inc",
                 }

               );


                //Alumni Profile Entries 5
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Jessica Santos</ li>" +
                     "<li>Course: Bachelor of Science Business Administration(Marketing Management)</li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: jls@sunrise-search.com</ li>" +
                     "<li>Latest work: Overseas man power provider </ li>" +
                     "<li>Description : Conduct initial interviews to applicants based on the standard requirement of the hiring company." +
                     "Send complete file or pre qualified candidates for client Prepare necassary docs for POEA processing  and etc</li>" +
                     "</ul>",
                     Position = "Recruitment Specialist",
                     Location = "4th Flr Chipeco building Meralco Ave.Corner Shaw Blrd Pasig City",
                     IsPublished = true,
                     Company = "Sunrise search & support INC",
                 }

               );


                //Alumni Profile Entries 6
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: MARY ANNE C. CALING</ li>" +
                     "<li>Course: Bachelor of Science Business Administration(HRDM)</li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address:maryannecaling@gmail.com</ li>" +
                     "<li>Latest work:HR Staff</ li>" +
                     "<li>Description : Responsilbe for maintining, Updating and monitoring employee work schedule, Compile and submint data for payroll cut-off and analyzing the payroll queries of employees.</li>" +
                     "</ul>",
                     Position = " Compensation and benefits (timekeeper)",
                     Location = "Fab Mariveles,BATAAN",
                     IsPublished = true,
                     Company = "DLX BAGS PHILS INC",
                 }

               );



                //Alumni Profile Entries 7
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Charlotte T. Lingad</ li>" +
                     "<li>Course: Bachelor of Science Business Administration (Financial Management)</ li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: basalocharlotte@gmail.com</ li>" +
                     "<li>Latest work:none</li>" +
                     "</ul>",
                     Position = "none",
                     Location = "none",
                     IsPublished = true,
                     Company = "none",
                 }

               );


                //Alumni Profile Entries 8
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Denice Patricia C Poblete</ li>" +
                     "<li>Course:Bachelor of Science Business Administration (Human Resources Development Management)</ li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: denicepoblete_19@yahoo.com</ li>" +
                     "<li>Latest work: I.T-Software Development </ li>" +
                     "<li>Description : incharge with the overall facets of HR Department</li> " +
                     "</ul>",
                     Position = "Human Resource(HR)",
                     Location = "Clark, Pampanga",
                     IsPublished = true,
                     Company = "Z Getcare Systems Inc.",
                 }

               );


                //Alumni Profile Entries 9
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: MYLEN D. MAGALLANES</ li>" +
                     "<li>Course:Bachelor of Science Business Management</li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: mylen.magallanes@gmail.com</ li>" +
                     "<li>Latest work:2ND MUCC/pension loan</li>" +
                     "<li>Description : Micro Finance/Lending Institution<li>" +
                     "</ul>",
                     Position = "OIC",
                     Location = "Dinalupihan, Bataan",
                     IsPublished = true,
                     Company = "2ND MUCC",
                 }

               );



                //Alumni Profile Entries 10
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Maricar M Naguiat</li>" +
                     "<li>Course: Bachelor of Science Criminology</li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: maricarnaguiat01@gmail.com</ li>" +
                     "<li>Latest work: Jail Officer</li>" +
                     "<li>Department: Municipal Disaster Risk Reduction and Management Office (MDRRMO)</li>" +
                     "</ul>",
                     Position = "Jail Officer 1",
                     Location = "San Jose Delmonte City Bulacan",
                     IsPublished = true,
                     Company = "Bureau of Jail Management and Penology",
                 }

               );



                //Alumni Profile Entries 11
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Mark D. Javier</ li>" +
                     "<li>Course: Bachelor of Science Custom Administration</li>" +
                     "<li>Gender: Male</li>" +
                     "<li>Email Address: markjavier219@gmail.com </li>" +
                     "<li>Latest work:Jiemei Agri Industrial corp</ li>" +
                     "<li>Department: Municipal Disaster Risk Reduction and Management Office (MDRRMO)</li>" +
                     "</ul>",
                     Position = "Manager",
                     Location = "Manila",
                     IsPublished = true,
                     Company = "...",
                 }

               );



                //Alumni Profile Entries 12
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Rovilyn Cano</ li>" +
                     "<li>Course: Bachelor of Science Customs Administration</ li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address:  rcano@nnrusa.com</ li>" +
                     "<li>Latest work: International Freight Forwarder</li>" +
                     "<li>Department: Municipal Disaster Risk Reduction and Management Office (MDRRMO)</li>" +
                     "<li>Description : Manage and Updating http//nnr.WebCargo.net Systems. Preparing rates, adhocs within time frame. Preparing reports as per by our Boss in US, at the same assisting him.  </ li>" +
                     "</ul>",
                     Position = " US Tender-Data Analyst/Key Account administrator",
                     Location = "Room 6, Skyfreight Building D. Skyfreight Center. Naia Avenue, Brgy. Sto Niño Parañaque City, Philippines",
                     IsPublished = true,
                     Company = "NNR Global Logistics Philippines Inc. (Global Accounts)",
                 }

               );



                //Alumni Profile Entries 13
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Rica May C.Miranda</ li>" +
                     "<li>Course:  Bachelor of Science in Travel Management </ li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address:  rmaemiranda02@gmail.com</ li>" +
                     "<li>Latest work:Dining attendant </ li>" +
                     "<li>Department: Municipal Disaster Risk Reduction and Management Office (MDRRMO)</li>" +
                     "</ul>",
                     Position = "...",
                     Location = "Subic Bay Waterfrontroad Moon Bay Marina",
                     IsPublished = true,
                     Company = "Terrace hotel",
                 }

               );



                //Alumni Profile Entries 14
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Lois Mae Paguinto</li>" +
                     "<li>Course: Bachelor of Science in Travel Management </ li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: loismaep051296@yahoo.com</ li>" +
                     "<li>Latest work:Billing Executive </ li>" +
                     "<li>Department: Municipal Disaster Risk Reduction and Management Office (MDRRMO)</li>" +
                     "</ul>",
                     Position = "BPO SG Billing Executive",
                     Location = "Paranaque City Philippines",
                     IsPublished = true,
                     Company = "Bollore Logistics Asia Support Services Inc.",
                 }

               );



                //Alumni Profile Entries 15
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Rodel Tala</ li>" +
                     "<li>Course: Bachelor of Science Customs Admistration</li>" +
                     "<li>Gender: Male</li>" +
                     "<li>Email Address: rodeltala.customs@gmail.com</li>" +
                     "<li>Department: Municipal Disaster Risk Reduction and Management Office (MDRRMO)</li>" +
                     "</ul>",
                     Position = "Air Import Operator",
                     Location = "Parañaque Metro Manila",
                     IsPublished = true,
                     Company = "Bollore Logistics",
                 }

               );


                //Alumni Profile Entries 16
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7fe5a275-0fa9-4c94-be94-f27fc6c06573"),
                     Description =
                     "<ul>" +
                     "<li>Name: Jeannilyn Velasquez</ li>" +
                     "<li>Course: Bachelor of Science Customs Administration</ li>" +
                     "<li>Gender: Female</li>" +
                     "<li>Email Address: jeannilynvelasquez@gmail.com</ li>" +
                     "<li>Latest work: Customs processor</li>" +
                     "</ul>",
                     Position = "Customs Broker/ Customs Representative",
                     Location = "Port Area Manila",
                     IsPublished = true,
                     Company = "MCPT Customs Brokerage",
                 }

               );
            }

                this._context.SaveChanges();
                return "OK";
            
        }

    }
}

