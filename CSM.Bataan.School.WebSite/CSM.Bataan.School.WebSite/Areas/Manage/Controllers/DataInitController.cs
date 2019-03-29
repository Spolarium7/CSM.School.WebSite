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
                           Id = Guid.Parse("000924ed-9f44-4646-bd1e-943adc34714d"),
                           Description = "CSS rooms use for Tesda training for the Computer Systrem Servicing NC2 for college , senior  high school and Tesda scholars...",
                           Content = "Comlab1 allowed to the grade school for them to get familiarize  to the computer or laptop to perform basic activities using computer.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "CSD room",
                          
                       }
                   );

              
                //Initialize SchoolFacility 2
                this._context.SchoolFacilities.Add(
                   new SchoolFacility()
                   {
                       Id = Guid.Parse("02a83712-6a73-4180-89bd-91dc7b64dd39"),
                       Description = "Our school parking area",
                       Content = "Available parking area for parents, visitors and employees , Parking Area School parking lot can accommodate fifteen vehicles together with the assistance of the security personnel.",
                       IsPublished = true,
                       PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                       Title = "Parking Area",
                   }
               );

                //Initialize SchoolFacility 3
                this._context.SchoolFacilities.Add(
                   new SchoolFacility()
                   {
                       Id = Guid.Parse("0e87ae7a-f195-46ec-935f-98b85cc9c168"),
                       Description = "The students use the VGD room for computer subjects... ",
                       Content = "The students use the VGD room for computer subjects like photo and logo design. It is also used for assessments. Lastly, BSIS students use it for their classes.",
                       IsPublished = true,
                       PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                       Title = "Visual, Graphic Design Lab Room",
                     
                   }
               );

                //Initialize SchoolFacility 4
                this._context.SchoolFacilities.Add(
                   new SchoolFacility()
                   {
                       Id = Guid.Parse("06673746-33b3-49d7-ab03-1e6526233d45"),
                       Description = "Our gymnasium is a mult-purpose hall..",
                       Content = "Our gymnasium is a mult-purpose hall that is used for aquitance parties, and various programs that require a large area. It is also used for physical activities like dancing, basketball and volleyball. The criminolgy students use it for their formations and physical activities.",
                       IsPublished = true,
                       PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                       Title = "Gymnasium",
                   }

               );

               // //Initialize SchoolFacility 5
               // this._context.SchoolFacilities.Add(
               //    new SchoolFacility()
               //    {
               //        Id = Guid.Parse("23d5de16-b791-4ec9-bdae-90740fa923bd"),
               //        Description = "There is an accounting office called Window 1 & Window 2...",
               //        Content = "There is an accounting office called Window 1." +
               //        " There a student can get information about what they owe for things like school uniforms, paper, notebooks, tuition, uniforms and other fees. " +
               //        "Window 2 is the cashier's office where the payment is actually made.",
               //        IsPublished = true,
               //        PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
               //        Title = "Window 1 Office & Window 2 Office",
               //    }
               //);

                //Initialize SchoolFacility 6
                this._context.SchoolFacilities.Add(
                           new SchoolFacility()
                           {
                               Id = Guid.Parse("084bc29e-c46a-4513-8d33-b3d5dbf86687"),
                               Description = "An area equipped with all the needed tools..",
                               Content = "An area equipped with all the needed tools and materials needed for smooth and efficient  FOOD AND BEVERAGE TRAINING.",
                               IsPublished = true,
                               PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                               Title = "Food and Beverages",
                           }
                       );

               // //Initialize SchoolFacility 7
               // this._context.SchoolFacilities.Add(
               //    new SchoolFacility()
               //    {
               //        Id = Guid.Parse("4ef0e59d-41d5-4005-80d5-204987688699"),
               //        Description = " The school also provides comfort rooms ...",
               //        Content = " The school also provides comfort rooms with comfortable toilets students can use at their convenience. The men's comfort rooms also features an urinal that many male like.",
               //        IsPublished = true,
               //        PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
               //        Title = "Male and female comfort rooms",
               //    }
               //);

                //Initialize SchoolFacility 8
                this._context.SchoolFacilities.Add(
                   new SchoolFacility()
                   {
                       Id = Guid.Parse("732015d4-367f-47a5-b065-4a46481d9603"),
                       Description = "CSM also have  a library for the students.. ",
                       Content = "CSM also have  a library for the students want to search about thier lecture,  sometimes library room use for meeting.",
                       IsPublished = true,
                       PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                       Title = "Library Room",
                      
                   }
               );

                //Initialize SchoolFacility 9
                this._context.SchoolFacilities.Add(
                        new SchoolFacility()
                        {
                            Id = Guid.Parse("41c6ba19-4010-49c3-bf6e-4cbc17cb258a"),
                            Description = "School canteen,  is very convenient..",
                            Content = "School canteen,  is very convenient. The middle and highschool students can put money on their  ID so when they want to buy food in the canteen they can just use their school ID to pay for it",
                            IsPublished = true,
                            PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                            Title = "Canteen",
                           

                        }
                    );


                //Initialize SchoolFacility 10
                this._context.SchoolFacilities.Add(
                   new SchoolFacility()
                   {
                       Id = Guid.Parse("4986cb84-0fde-4da5-972c-5c285c32b7a8"),
                       Description = "Marketing Office is one of the busy office in our campus...",
                       Content = "Marketing Office is one of the busy office in our campus. We ensure that every client who comes to our school will received all the information they need to know with regards to our humble institution." +
                       "Our marketing staffs are always busy the whole year round conducting a career orientations to every schools from basic education upto high school for proper endorsement of our school." +
                       "We also keep on updating our clients with our events, class suspension, announcement, etc.",
                       IsPublished = true,
                       PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                       Title = "Marketing Office",
                   }
               );



                //Initialize SchoolFacility  11
                this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("e8c95c34-26f5-4e1f-bfcb-e19a6808fd87"),
                           Description = "Our school also features a well-equipped clinic...",
                           Content = "Our school also features a well-equipped clinic for students who are ill or need to rest. A professional nurse works there to provide medical treatment to those in need of first-aid.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "School Clinic",

                       }
                   );

                //Initialize SchoolFacility 12
                this._context.SchoolFacilities.Add(
                   new SchoolFacility()
                   {
                       Id = Guid.Parse("da51b1f9-a7f7-481e-a60a-83251d1124de"),
                       Description = "The registrar room is an office..",
                       Content = "The registrar room is an office staffed with friendly employees who can help you with items such as enrollment requirements," +
                       " what subjects are available, what course is open, how to get a diploma, a transcript of what a student studied and their grades," +
                       " and how a student get a special exams for college.",
                       IsPublished = true,
                       PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                       Title = "Registrar Office",
                   }
               );


                //Initialize SchoolFacility 13
                this._context.SchoolFacilities.Add(
                       new SchoolFacility()
                       {
                           Id = Guid.Parse("f25752f2-3b42-4e49-85a0-d6fa296b3ef3"),
                           Description = "In the guidance office students can receive counseling about problems they're having...",
                           Content = "In the guidance office students can receive counseling about problems they're having. " +
                       "They can also obtain guidance about what career options are available to them.",
                           IsPublished = true,
                           PostExpiry = DateTime.UtcNow.AddMonths(3).AddDays(1),
                           Title = "Guidance Office",

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
                      Id = Guid.Parse("75f70d2f-0362-4e9c-a117-3e15ead48aab"),
                      Description = "She is Erza Alfonzo, she studied  Bachelor of Science Criminology. She's working as Rescuer at Department of Municipal Disaster Risk Reduction and Management Office(MDRRMO). ",    
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
                     Id = Guid.Parse("eac64419-0a56-45c7-add0-1eb026351b4c"),
                     Description =
                     "She is Darlene Shane Santos, she studied  Bachelor of Science Custom Administration. She's working as Sales Marketing Officer at toyota company",
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
                     Id = Guid.Parse("70ae75c5-e39a-4c8a-9f8a-238775ad6f43"),
                     Description = "She is Almira S. Banzon, she studied  Bachelor of Science Information Systems,She's also a Deserved Student Asssistant or a scholar of College Subic Montessori. She's  working as Associate Registrar at College of Subic Montessori Inc.",
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
                     Id = Guid.Parse("6b0512b5-39a5-415b-9845-b9ad465b0873"),
                     Description = "He is John Paul C Pamintuan, she studied  Bachelor of Science Business Administration(Marketing Management). He's  working as Professional Medical Representative in Kaufmann Pharma Inc",
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
                     Id = Guid.Parse("74e7a1aa-bced-4b22-a6b6-a3f25f5f1e44"),
                     Description = "She is Jessica Santos, she studied  Bachelor of Science Business Administration(Marketing Management).She's  working as Overseas man power provider in Sunrise search & support INC , Her work is  Conduct initial interviews to applicants based on the standard requirement of the hiring company." +
                     "Send complete file or pre qualified candidates for client Prepare necassary docs for POEA processing  and etc ",
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
                     Id = Guid.Parse("3b8c7209-6c9a-4c0a-83f5-f1ad51bdac0f"),
                     Description = "She is MARY ANNE C. CALING, she studied  Bachelor of Science Business Administration(HRDM).She's  working as HR Staff in DLX BAGS PHILS INC , Her work is  Responsilbe for maintining, Updating and monitoring employee work schedule, Compile and submint data for payroll cut-off and analyzing the payroll queries of employees.",
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
                     Id = Guid.Parse("09a476e7-d217-47e6-b172-be83d429a3a7"),
                     Description = "She is Charlotte T. Lingad, she studied  Bachelor of Science Business Administration (Financial Management).",   
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
                     Id = Guid.Parse("a422143f-4f3d-4192-ae45-204527d96566"),
                     Description = "She is Denice Patricia C Poblete, she studied  Bachelor of Science Business Administration (Human Resources Development Management).She's  working as I.T-Software Development in Z Getcare Systems Inc. , Her work is  incharge with the overall facets of HR Department ",
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
                     Id = Guid.Parse("89497382-766e-43c1-a274-bc6c67c129c1"),
                     Description = "She is MYLEN D. MAGALLANES, she studied  Bachelor of Science Business Management.She's  working as 2ND MUCC/pension loan in 2ND MUCC , Her work is Micro Finance/Lending Institution",
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
                     Id = Guid.Parse("4a8d5aeb-55db-4256-a3dc-e9d3e6da0e49"),
                     Description = "She is Maricar M Naguiat, she studied  Bachelor of Science Criminology.She's  working as Jail Officer in Bureau of Jail Management and Penology , Her work is  Responsilbe for maintining, Updating and monitoring employee work schedule, Compile and submint data for payroll cut-off and analyzing the payroll queries of employees.",
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
                     Id = Guid.Parse("f0547387-5b67-4e28-bba7-92b378bf31c0"),
                     Description = "He is Mark D. Javier, she studied  Bachelor of Science Custom Administration.He's  working as Jiemei Agri Industrial corp in Jiemei Agri Industrial corp ",  Position = "Manager",
                     Location = "Manila",
                     IsPublished = true,
                     Company = "Jiemei Agri Industrial corp",
                 }

               );



                //Alumni Profile Entries 12
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("8ca8fa5f-5de3-496d-813b-0a45c608d76f"),
                     Description = "She is Rovilyn Cano, she studied  Bachelor of Science Customs Administration.She's  working as International Freight Forwarder in NNR Global Logistics Philippines Inc. (Global Accounts) , Her work is   Manage and Updating http//nnr.WebCargo.net Systems. Preparing rates, adhocs within time frame. Preparing reports as per by our Boss in US, at the same assisting him. ", 
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
                     Id = Guid.Parse("5034489e-f54f-484d-b6af-d385d5cd922e"),
                     Description = "She is Rica May C.Miranda, she studied  Bachelor of Science in Travel Management.She's  working as Dining attendant in Terrace hotel , Her work is  Responsilbe for maintining, Updating and monitoring employee work schedule, Compile and submint data for payroll cut-off and analyzing the payroll queries of employees.",
                     Location = "Subic Bay Waterfrontroad Moon Bay Marina",
                     IsPublished = true,
                     Company = "Terrace hotel",
                 }

               );



                //Alumni Profile Entries 14
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("14f36a9f-6921-4d30-ae18-8e4e92b57ce0"),
                     Description = "She is Lois Mae Paguinto, she studied Bachelor of Science in Travel Management.She's  working as Billing Executive in Bollore Logistics Asia Support Services Inc. , Her work is  Responsilbe for maintining, Updating and monitoring employee work schedule, Compile and submint data for payroll cut-off and analyzing the payroll queries of employees.",
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
                     Id = Guid.Parse("ea8fea9e-8402-410d-bc64-1aea7e137a8b"),
                     Description = "He is Rodel Tala, she studied Bachelor of Science Customs Admistration.He's  working in Bollore Logistics",
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
                     Id = Guid.Parse("830745c4-76de-42fb-a323-a461172f0711"),
                     Description = "She is Jeannilyn Velasquez, she studied  Bachelor of Science Customs Administration.She's  working as Customs processor in MCPT Customs Brokerage ",
                     Position = "Customs Broker/ Customs Representative",
                     Location = "Port Area Manila",
                     IsPublished = true,
                     Company = "MCPT Customs Brokerage",
                     
                 }

               );

                //Alumni Profile Entries 17
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("d90abb98-8170-4f4c-aaa0-070ee67fba7b"),
                     Description = "He is Rafael R. Capio, he studied Bachelor of Science Business Administration(Human Resources Development Management).he's  working as  Overseas man power provider in Devisers Immigration Law Firm , He work is Making a feasibility study and business plan to a certain company or individual who is trying to establish a business in the UK or trying to migrate in EUROPEAN country.",
                     Position = "Business Planner",
                     Location = " JLT DUBAI UAE",
                     IsPublished = true,
                     Company = "Devisers Immigration Law Firm",
                 }
                    );

                //Alumni Profile Entries 18
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("11da1a5e-b369-403e-aa9f-60a2a077d54c"),
                     Description = "She is Sangalang Darwin M., she studied  Bachelor of Science Customs Administration.She's  working as Quality assurance in Sumi phil.",
                     Position = "First Visual",
                     Location = "Palihan",
                     IsPublished = true,
                     Company = "Sumi phil.",
                 }
                    );


                //Alumni Profile Entries 19
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("33369ff4-0793-4fe9-b121-ab10820f8c33"),
                     Description = "He is Brandon Michole Delos Santos he studied Hotel Restaurant Services).he's  working as CSM Position: SAFETY OFFICER in AIM HIGH , He work is  to fulfill the safety measure within the school campus and the safety of all employees and students.",
                     Position = "First Visual",
                     Location = "Sta. Isabel highway,  Dinalupihan, bataan",
                     IsPublished = true,
                     Company = "AIM HIGH",
                 }
                    );





                //Alumni Profile Entries 20
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("6d912ff6-df67-42e2-a089-1f0f755edec6"),
                     Description = "He is JOHN KING MANUEL ALVARO , he studied Bachelor of Science Information System.he's  working as CSM Faculty in College of Subic Montessori, INC.",
                     Position = "INSTRUCTOR/COSTODIAN",
                     Location = "Sta.Isabel Dinalupihan, Bataan. ",
                     IsPublished = true,
                     Company = "College of Subic Montessori, INC.",
                 }
                    );


                //Alumni Profile Entries 21
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("c9ed386d-424c-4c0f-9bfb-1a98c26c75fb"),
                     Description = "He is  Clarence D. Idio , he studied Bachelor of Science Criminology.She's  working as Police Officer 1 in PNP.",
                     Position = "Police Office 1",
                     Location = "",
                     IsPublished = true,
                     Company = "PNP",
                 }
                    );


                //Alumni Profile Entries 22
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("69f24d79-2670-43b8-a361-ac4c419b15b8"),
                     Description = "She is Krizia Kaye C. Talaroc, she studied Bachelor of Science Customs Administration.She's  working as School Registrar in College of Subic Montessori-Lincoln Heights, Inc.",
                     Position = " Registrar Company: College of Subic Montessori - Lincoln Heights, Inc. ",
                     Location = "Lincoln Heights, San Pablo, Dinalupihan, Bataan",
                     IsPublished = true,
                     Company = "College of Subic Montessori-Lincoln Heights, Inc. ",
                 }
                    );



                //Alumni Profile Entries 23
                this._context.AlumniProfiles.Add(
                 new AlumniProfile()
                 {
                     Id = Guid.Parse("7dd5356d-9312-43f0-bdfb-a07aa71d7d82"),
                     Description = "He is Rafael R. Carpio , she studied   Bachelor of Science Business Administration-Human Resouce Development Management.he's  working as Business Planner in Devisers Immigration Law Firm , He work Making a feasibility study and business plan to a certain company or individual who is trying to establish a business in the UK or trying to migrate in EUROPEAN country.",
                     Position = "",
                     Location = "LT DUBAI UAE",
                     IsPublished = true,
                     Company = " Devisers Immigration Law Firm",
                 }
                    );



                ////Alumni Profile Entries 24
                //this._context.AlumniProfiles.Add(
                // new AlumniProfile()
                // {
                //     Id = Guid.Parse(""),
                //     Description =
                //     "<ul>" +
                //     "<li>Name: </ li>" +
                //     "<li>Course:</li>" +
                //     "<li>Gender:</li>" +
                //     "<li>Email Address: </ li>" +
                //     "<li>Latest work:  </ li>" +
                //     "Description :.",

                //     Position = "",
                //     Location = "",
                //     IsPublished = true,
                //     Company = "",
                // }
                //    );



                ////Alumni Profile Entries 25
                //this._context.AlumniProfiles.Add(
                // new AlumniProfile()
                // {
                //     Id = Guid.Parse(""),
                //     Description =
                //     "<ul>" +
                //     "<li>Name: </ li>" +
                //     "<li>Course:</li>" +
                //     "<li>Gender:</li>" +
                //     "<li>Email Address: </ li>" +
                //     "<li>Latest work:  </ li>" +
                //     "Description :.",

                //     Position = "",
                //     Location = "",
                //     IsPublished = true,
                //     Company = "",
                // }
                //    );



                ////Alumni Profile Entries 26
                //this._context.AlumniProfiles.Add(
                // new AlumniProfile()
                // {
                //     Id = Guid.Parse(""),
                //     Description =
                //     "<ul>" +
                //     "<li>Name: </ li>" +
                //     "<li>Course:</li>" +
                //     "<li>Gender:</li>" +
                //     "<li>Email Address: </ li>" +
                //     "<li>Latest work:  </ li>" +
                //     "Description :.",

                //     Position = "",
                //     Location = "",
                //     IsPublished = true,
                //     Company = "",
                // }
                //    );




                ////Alumni Profile Entries 27
                //this._context.AlumniProfiles.Add(
                // new AlumniProfile()
                // {
                //     Id = Guid.Parse(""),
                //     Description =
                //     "<ul>" +
                //     "<li>Name: </ li>" +
                //     "<li>Course:</li>" +
                //     "<li>Gender:</li>" +
                //     "<li>Email Address: </ li>" +
                //     "<li>Latest work:  </ li>" +
                //     "Description :.",

                //     Position = "",
                //     Location = "",
                //     IsPublished = true,
                //     Company = "",
                // }
                //    );





                ////Alumni Profile Entries 28
                //this._context.AlumniProfiles.Add(
                // new AlumniProfile()
                // {
                //     Id = Guid.Parse(""),
                //     Description =
                //     "<ul>" +
                //     "<li>Name: </ li>" +
                //     "<li>Course:</li>" +
                //     "<li>Gender:</li>" +
                //     "<li>Email Address: </ li>" +
                //     "<li>Latest work:  </ li>" +
                //     "Description :.",

                //     Position = "",
                //     Location = "",
                //     IsPublished = true,
                //     Company = "",
                // }
                //    );

            }

            //Initialize Courses
            if (this._context.Courses.Count() < 1)
            {


                //Courses 1 Casa Department 
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("3f33a7dd-bacb-48b2-9a01-85a19dfc9331"),
                      Description =
                      "<dl>" +
                      "<dt>Casa Department </dt>" +
                      "<dd> ( 2 to 3 years old.)" +
                      "The toddler year are a time of great cognitive emotional and social development.</dd>" +
                      "</dl>",
                      Content = "Your Child is advancing from infancy toward and into the preschool years <hr>" +
                      "during this time, his physical growth and motor development will slow, but expect to see some tremendous intellectual, social, and emotional changes.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Toddler",
                  }

                );

                //Courses 2 Casa Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("b62dc20c-5805-4772-a2ec-e483f805fd95"),
                      Description =
                      "<dl>" +
                      "<dt>Casa Department </dt>" +
                      "<dd>(3 to 4 years old) " +
                      " The school helps the child develop his/her speech, order, coordination of movement and independence ," +
                      "through self-care and care of the environment.<dd>" +
                      "</dl>",
                      Content = "there are hands-on learning materials covering various concepts and activities on cultural arts,language, mathematics. All subjects directly or inderectly help the child develop ares of his/her personal growth" +
                      "physically,mentally, emotionally, socially and morally.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Junior Casa",
                  }

                );


                //Courses 3 Casa Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("7e7f267b-0245-4020-b7a5-bf4e9d3793d8"),
                      Description =
                      "<dl>" +
                      "<dt>Casa Department</dt>" +
                      "<dd>(4 to 5 years old.)" +
                      " most of the children have attended previus levels and have acquired order, precision in movement, attention and concentration.</dd>" +
                      "</dl>",
                      Content = "there are hands-on learning materials covering various concepts and activities on cultural arts,language, mathematics. All subjects directly or inderectly help the child develop ares of his/her personal growth" +
                      "physically,mentally, emotionally, socially and morally.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Senior Casa",
                  }

                );


                //Courses 4 Casa Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("f23002f6-9c49-4d33-9e95-b396ce62ee20"),
                      Description =
                      "<dl>" +
                      "<dt>Casa Department </dt>" +
                      "<dd>(5 to 6 years old.)" +
                      "Children have acquired a higher level of maturity and therefore, are capable of accomplishing a great deal of mental work</dd>" +
                      "</dl>",
                      Content = "there are hands-on learning materials covering various concepts and activities on cultural arts,language, mathematics. All subjects directly or inderectly help the child develop ares of his/her personal growth" +
                      "physically,mentally, emotionally, socially and morally.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Advanced Casa",
                  }

                );



                //Courses 5 Primary Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("8daeb7ee-4e82-4f99-b956-d7dc69f59c6c"),
                      Description =
                      "<dl>" +
                      "<dt>Primary Department</dt>" +
                      "<dl>(6 to 7 years old.)<hr>" +
                      "The first school year after kindergarte.</   dl>" +
                      "</dl>",
                      Content = "Child will experience the fun of communicating, learning and expressing themselves. Students will see why words are important and how words can be used to create beautiful stories.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade One (1)",
                  }

                );




                //Courses 6 Primary Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("c7d7b51f-fc9d-428f-bca5-c736402bc960"),
                      Description =
                      "<dl>" +
                      "<dt>Primary Department </dt>" +
                      "<dl>(7 to 8 years old.)" +
                      "The second layer of the foundation of a childs primary education.</dl>" +
                      "</dl>",
                      Content = "Students are taught subjects such as Math, Science, Geography and Social Studie.s",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Two (2)",
                  }

                );



                //Courses 7 Primary Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("d8f269e8-7214-4ce5-a151-9252cb963710"),
                      Description =
                      "<dl>" +
                      "<dt>Primary Department </dt>" +
                      "<dd>(8 to 9 years old.)" +
                      "Student begin working more on text comprehension, Student also begin reading harder chapter books.</dd>" +
                      "</dl>",
                      Content = "Students are usually introduced to multiplication and division facts,place value to thousands or ten thousands, and estimation.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Three (3)",
                  }

                );




                //Courses 8 Primary Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("f86a1dbb-3403-4fb8-a6b7-6ac2192009ce"),
                      Description =
                      "<dl>" +
                      "<dt>Primary Department </dt>" +
                      "<dd>(9 to 10 years old.)" +
                      " Students master and further their multiplication,division and general computation skills<dd>" +
                      "</dl>",
                      Content = "They learn how to solve real-life word problems using the four basic operation and larger numbers.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Four (4)",
                  }

                );




                //Courses 9 Primary Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("8de1007c-ffe4-4f23-a489-ef5629eaceeb"),
                      Description =
                      "<dl>" +
                      "<dt>Primary Department </dt>" +
                      "<dd>10 to 11 years old." +
                      "Children word hard on projects and tasks.<dd>" +
                      "</dl>",
                      Content = "It requires them to draw on the skills and strategies they have been learning in elementary school.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Five (5)",
                  }

                );

                //Courses 10 Primary Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("d45dc7ca-50d8-42b7-9718-59b233d3d4cb"),
                      Description =
                      "<dl>" +
                      "<dt>Primary Department </dt>" +
                      "<dd>(11 to 12 years old.)" +
                      "is a time for changes, a time to discover more about themselves and working with each other</dd>" +
                      "</dl>",
                      Content = "Develop the leadership skills, learn the importance of teamwork, discover the potential and grow in responsibility and confidence to make good choices.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Six (6)",
                  }

                );

                //Courses 11 Junior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("c905f4af-c3c3-4f5f-9a05-54d3b2bdec6e"),
                      Description =
                      "<dl>" +
                      "<dt>Middle School Department </dt>" +
                      "<dd>(12 to 13 years old.)" +
                      "Students move steadily into early adolescence and two basic characteristics</dd>" +
                      "</dl>",
                      Content = " a strong desire for knowledge about the world and a budding capacity for self-reflection students develop capacity to recite alone and to give a short talks on a prepared topic.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Seven (7)",
                  }

                );

                //Courses 12 Junior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("0a8db810-c1b1-4b58-b12c-6285bb9d0d0a"),
                      Description =
                      "<dl>" +
                      "<dt>Junior High School Department</dt>" +
                      "<dd>(13 to 14 years old.)" +
                      "students take six required subjects to learn more about themselves.</dd>" +
                      "</dl>",
                      Content = "These are English, Language arts, health and life skills,mathematics, physical education, science and social studies.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eight (8)",
                  }

                );


                //Courses 13 Junior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("ab1da848-5dfd-420f-ba41-44813fbc0188"),
                      Description =
                      "<dl>" +
                      "<dt>Junior High School Department</dt>" +
                      "<dd>(14 to 15 years old.)" +
                      "Experience a challenging and stimulating style of school level curriculum.</dd>" +
                      "</dl>",
                      Content = "Student delve into classics, develop a more so sophisticated style of writing, and hone their public speaking skills.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Nine (9)",
                  }

                );


                //Courses 14 Junior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("ec55ecff-8d67-4628-b7f9-2d1b692114a8"),
                      Description =
                      "<dl>" +
                      "<dt>Junior High School Department</dt>" +
                      "<dd>(15 to 16 years old.)" +
                      "Tenth year after the first introductory year upon entering compulsory schooling</dd>" +
                      "</dl>",
                      Content = "Students read and respond to historically or culturally significant works of literature that reflect and enhance their studies of history and socical science.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Ten (10)",
                  }

                );


                //Courses 15 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("1c67997b-9701-42fc-aff5-caf58ff57abb"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd> ABM : Accountancy Business Management" +
                      "pne of the tracks introduced by the  K to 12 program the accountancy, business and managements.</dd>" +
                      "</dl>",
                      Content = "Subjects are applied economics,business finance, fundamentals of accountancy, business and management, principles of marketing, business mathematics.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven (11)",
                  }

                );



                //Courses 16 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("f2b5c9ff-395b-4759-bb6f-f4855326abda"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd> STEM : Science Technology,Engineering and Mathematics intertwining disciplines when applied in the real world. " +
                      "</dd>" +
                      "</dl>",
                      Content = "Subjects are science, technology, engineering and mathematics. These are the foundations of the industrial and corporate world.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven (11)",
                  }

                );




                //Courses 17 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("e6176b0f-1620-4900-a473-f377ea2fdd11"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>HUMSS : Humanities and Social Sciences</dd>" +
                      "</dl>",
                      Content = "This strand is for learners who aim to take up jounalism,communication arts, liberal arts, education and other social science related courses in college.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven (11)",
                  }

                );



                //Courses 18 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("fb288ff2-1082-4b06-abd9-315fc0b02ff5"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>GAS : General Academic Strand</dd>" +
                      "</dl>",
                      Content = "is great for students who are still undecided on which tract to take.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven(11)",
                  }

                );



                //Courses 19 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("a33390f9-8ab5-4071-8b37-58baea4db388"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>ICT : Information Computer Technology</dd>" +
                      "</dl>",
                      Content = "is one of the stands offered in the Technical-Vocational-Livelihood Track in senior high school. it is designed to provide you with the technical skill and knowledge" +
                      "in using tools and equipment that allows people to interact in the digital world.",
                      IsPublished = true,
                      Title = "Grade Eleven(11)",
                  }

                );



                //Courses 20 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("e25a52da-ba8c-4151-88b8-ab69b6e9cf0b"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>HE : Home Economics</dd>" +
                      "</dl>",
                      Content = "This Framework compromises two seperate strands for students to have in depth study of a specific area under H.E. They could choose either the food" +
                      "science and technology strand or the Fashion,Clothing and Textiles.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven(11)",
                  }

                );



                //Courses 21 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("bfb6ddf9-340e-4496-a3c8-82644272626d"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>ABM : Accountancy,Business and Management.</dd>" +
                      "</dl>",
                      Content = "Focus on the basic concepts of financial management. Business management corporate operations and all things that are accounted for.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven(12)",
                  }

                );

                //Courses 22 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("f8b604e0-b631-4437-a372-b8f5e31deda2"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>STEM : Science,Technology,Engineering and Mathematics.</dd>" +
                      "</dl>",
                      Content = "Focus on the curriculum is to provide practical learning experinces in order for students to understand the concepts beter through application controlled experiments,research and practice.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven(12)",
                  }

                );


                //Courses 23 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("c84491ce-ed34-4a16-890a-f70766760157"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>HUMSS : Humanities and Social Sciences.</dd>" +
                      "</dl>",
                      Content = "Focus for those who wonder what is on the other side of the wall. In other words, you are ready to take on the world and talk to a lot of people.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven(12)",
                  }

                );

                //Courses 24 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("604adbf5-734e-48ee-a9c1-3ed75157f71f"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>GAS : General Academic Strand.</dd>" +
                      "</dl>",
                      Content = "Strand is purposively designed for those students who are still indecisive of what course or degree they want to pursue in college.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven(12)",
                  }

                );


                //Courses 25 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("6e6e570c-1e0b-457a-bb67-e9d5d707e864"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>ICT : Information Communication Technology.</dd>" +
                      "</dl>",
                      Content = "Professions that can be considered after this strand are as a graphic designer, encoder web developer, and designer.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven(12)",
                  }

                );


                //Courses 26 Senior High School Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("f0689c6e-629d-4f5b-a818-3fb448d0f6ec"),
                      Description =
                      "<dl>" +
                      "<dt>Senior High School Department</dt>" +
                      "<dd>H.E : Home Economics.</dd>" +
                      "</dl>",
                      Content = "Focuses on teaching you skills that can be useful in livelihood projects.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Grade Eleven(12)",
                  }

                );

                //Courses 27 College Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("3942c27b-dd92-4c87-ae58-f4802bc5f805"),
                      Description =
                      "<dl>" +
                      "<dt>College Department</dt>" +
                      "<dd>Bachelor of Science Criminolgy." +
                      "Studentss tend to study and gain knowledge in areas related to  the prevention causes and control of criminal activities</dd>" +
                      "</dl>",
                      Content = "Programs offer studies in criminal and deviant behavior, as well as government response to such behavior. Students may learn theories, policies, practices and laws associated with criminal behavior." +
                      "Students have the ability to learn about controvercial issues in criminal justice from experts in a variety of related fields, including policing,fraud or court systems.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "College BSCRIM.",
                  }

                );



                //Courses 28 College Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("f6d90270-e311-40bb-9bad-0c005aac2d16"),
                      Description =
                      "<dl>" +
                      "<dt>College Department</dt>" +
                      "<dd>Bachelor of Science Information Technology." +
                      "Program includes the study of application and effect of informatiion technology to organizations</dd>" +
                      "</dl>",
                      Content = "I.S a four year degree program that deal with the design and implementation of solutions that intergrate information technology with business" +
                      "processes. The program teaches students all about hardware and software applications and how they can use them to collect,filter, process, create and distribute data.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "College BSIS",
                  }

                );




                //Courses 29 College Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("b8cbdb7b-89ec-4604-8a53-c0850f87bad9"),
                      Description =
                      "<dl>" +
                      "<dt>College Department</dt>" +
                      "<dd>Bachelor of Science Customs Administrations." +
                      "A degree course for individuals who wish to pursue a career in customs brokerage or in the field of transportation and supply chain managements.</dd>" +
                      "</dl>",
                      Content = "A four year degree program that will train you in handing import and export operations.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "College BSCA",
                  }

                );





                //Courses 30 College Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("84a396b2-613d-4986-9448-93d3cdbf76b2"),
                      Description =
                      "<dl>" +
                      "<dt>College Department</dt>" +
                      "<dd>Bachelor of Science Travel Management." +
                      "Covers various components related to the travel and tour industry</dd>" +
                      "</dl>",
                      Content = "It includes tour and travel operationsm, events management , allied services , entertainment and recreation, tourism research and education andd tourism planning and development.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "College BSTM",
                  }

                );





                //Courses 31 College Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("721294d3-7a25-4a66-b979-853b5c1de6b8"),
                      Description =
                      "<dl>" +
                      "<dt>College Department</dt>" +
                      "<dd>Bachelor of Science Business Administration." +
                      "Possess a familiarity of business operations and equip them with critical decision making skills.</dd>" +
                      "</dl>",
                      Content = "The program empowers students with a basic and clear understanding of the functions of every division, be it in marketing, finance , operations human resourses and office management.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "College BSBA",
                  }

                );




                //Courses 32 College Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("bf872999-53ba-45d1-b065-a06d696319e9"),
                      Description =
                      "<dl>" +
                      "<dt>College Department</dt>" +
                      "<dd>Associate in Computer Technology." +
                      "Provides knowledge and skills in the fundamental of computer programming and basic computation</dd>" +
                      "</dl>",
                      Content = "The program also includes topics related to data structures, network concepts, computer organization , database management system and system analysis and design.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "College ACT",
                  }

                );

                //Courses 33 College Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("71c93ed0-097c-4d0b-b8ed-2a9f3fe0468d"),
                      Description =
                      "<dl>" +
                      "<dt>College Department</dt>" +
                      "<dd>Hotel Restaurant Services." +
                      "Its a two year program that designed to provide students with a through foundation on the skills required to begin a competetive career in the hotel and restaurant industry.</dd>" +
                      "</dl>",
                      Content = " Students will be prepared to earn national certificates on cookery , food and beverage services, bartending , front office and housekeeping.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "College HRS",
                  }

                );



                //Courses 34 Tesda Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("efee4d6d-49ec-40c0-b1c0-2c8f776501fd"),
                      Description =
                      "<dl>" +
                      "<dt>Tesda Offers</dt>" +
                      "<dd>Food and Beverage NC-II." +
                      " Program prepares you to start can international career in the hotel, restaurant or bar business.</dd>" +
                      "</dl>",
                      Content = " Teachers guide you through the learning modules and combine theory with hands-on, practical training. You will be given the opportunity" +
                      "to practice your skills with real customers in readiness for your transition into the job market.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Tesda Food and Beverage NC-II",
                  }

                );


                //Courses 35 Tesda Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("7b788245-41b9-4470-9a6b-717173179e88"),
                      Description =
                      "<dl>" +
                      "<dt>Tesda Offers</dt>" +
                      "<dd>Front Office NC-II." +
                      " Responsible for handling front office reception and administration duties.</dd>" +
                      "</dl>",
                      Content = " Including greetings guests and offering them a beverage, answering phones , handing company inquiries, and sorting and distributing mail.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Tesda Front Office NC-II",
                  }

                );

                //Courses 36 Tesda Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("6010c42c-ff01-4c21-bf06-c55bf29d71ce"),
                      Description =
                      "<dl>" +
                      "<dt>Tesda Offers</dt>" +
                      "<dd>Housekeeping NC-II." +
                      " Require cooking or food preparation and heavily cleaning.</dd>" +
                      "</dl>",
                      Content = "Train them how to be responsible for making sure all assigned areas of the home are clean, neat and tidy.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Tesda Housekeeping NC-II",
                  }

                );


                //Courses 37 Tesda Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("ccec071a-2075-4aa9-b533-95357270e4fa"),
                      Description =
                      "<dl>" +
                      "<dt>Tesda Offers</dt>" +
                      "<dd>Computer System Servicing NC-II." +
                      " Designed to develop knowledge, skills and attitudes of a computer service technician in accordance with industry standards.</dd>" +
                      "</dl>",
                      Content = "It covers basic and commong competencies such as installing maintaining, configuring , and diagnosing computer systems and networks.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Tesda Computer System Servicing NC-II",
                  }

                );



                //Courses 38 Tesda Department
                this._context.Courses.Add(
                  new Course()
                  {
                      Id = Guid.Parse("dbd0c36d-9e1f-4a4c-adaa-cdc775dc6b9d"),
                      Description =
                      "<dl>" +
                      "<dt>Tesda Offer</dt>" +
                      "<dd>Visual Graphic Design NC-II." +
                      " Designed to develop knowledge, skill.</dd>" +
                      "</dl>",
                      Content = "Train to design and develop visual graphic designs for print media electronic media, product packaging and both and product/window display.",
                      CourseCode = "",
                      IsPublished = true,
                      Title = "Tesda Visual Graphic Design NC-II",
                  }

                );






            }

            //Initialize Threads
            if (this._context.Threads.Count() < 1)
            {


                //Threads 1 
                this._context.Threads.Add(
                  new Thread()
                  {
                      Id = Guid.Parse("4c716f6b-3a12-4b42-ab39-cb13d9a1c229"),
                      Description = "CSM Education Offer & Requirements...",
                      Content = 
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
                      IsPublished = true,
                      Title = "What are the BASIC EDUCATION PROGRAMS",
                  }

                );



                //Threads 2 
                this._context.Threads.Add(
                  new Thread()
                  {
                      Id = Guid.Parse("ceaa51a9-5dd8-428d-9aec-9c307a3ca43d"),
                      Description = "Requirements for NEW STUDENT",
                    

                      Content = 
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
                      IsPublished = true,
                      Title = "What are the requirements for NEW STUDENT  " + "(For CASA to Senior HighSchool )",
                  }

                );


                //Threads 3 
                this._context.Threads.Add(
                  new Thread()
                  {
                      Id = Guid.Parse("051002cd-22e5-4d05-a38a-2e0d46ec2cdc"),     
                      Content = "<ul><li>1. CALL(047) 633-5531 or Email csm.bataan888@yahoo.com<li>" +
                        "<li>2. For New Students Submit admission requirements at the Register's Office and proceed to advising of subjects OIC-Principal - Basic Education Dept. Dean/OIC - College Head - Higher Education Dept. For OLD Student : Duly Signed Clearance<li> " +
                        "<li>3. For NEW/TRANSFEREES proceed to Guidance and Counseling Office for the Schedule of Assessment Exam, proceed to designated room for the measurement of uniform, For OLD Students proceed to Step 5<li>" +
                        "<li>4. proceed to Step 5  <li>" +
                        "<li>5. Proceed to Finance Office for the assessment of Fees<li> " +
                        "<li>6. Payment of assesed Tuition and other fees<li> " +
                        "<li>7. You are now officially ENROLLED (SPENDS A DAY AS A MONTESSORIAN!)</li></ul>",
                      Description = "For New Students Submit admission requirement....",
                      IsPublished = true,
                      Title = "How to inquire in CSM?",
                  }

                );



                //Threads 4 
                this._context.Threads.Add(
                  new Thread()
                  {
                      Id = Guid.Parse("f3a4e146-837e-40af-91cf-04e998cf596a"),    
                      Content = "Under Basic Education Curriculum:" +
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
                      Description = "CSM Bataan - CSM offers",
                      IsPublished = true,
                      Title = "Colleges of Subic Montessori -  offers )",
                  }

                );




                //Threads 5
                this._context.Threads.Add(
                  new Thread()
                  {
                      Id = Guid.Parse("5eadef3f-0d89-498e-b476-4d7da90539eb"),
                      Description ="The rules or illegal items ",
                       
                      Content = "<ul>" +
                        "<li>Complete Uniform</li>" +
                        "<li>I.D Student</li>" +
                        "<li>Short hair , no color</li> " +
                        "<li>No accessories</li>" +
                        "<li>Gadget is ban in school</li>" +
                        "<li>No smoking in school </li>" +
                        "<li>Outsider is ban </li>" +
                        "</ul>",
                      IsPublished = true,
                      Title = "What are the rules of CSM & illegal items",
                  }

                );


            }

            //Initialize Researches
            if (this._context.Researches.Count() < 1)
            {


                //Researches 1 
                this._context.Researches.Add(
                  new Research()
                  {
                      Id = Guid.Parse("6fcffca5-42ee-4cf2-b5e1-4e0afd0ac9f8"),
                      Content = "<h4>A System Analysis Development Project By:<hr>" +
                      "Torio, Gellie P. and Ponce, Omar S. - ACT</h4>" +
                      " Point of sale Inventory System is one of the essential components of a successful business." +
                      " It is a modern replacement for the cash register in retail applications. " +
                      "It can help to record securely all the sales and customer's orders, track products which are poor on business sales and course manage inventory. " +
                      "This is particular system can improve the way, the small and mid-sized businesses do their inventory and sales transaction. " +
                      "It will aid some common problems facing by business industries, that in this era of modernization, still using a manual process inventory." +
                      "Common problems like slow inventory process, lost records, inventory shortage, and high risk of errors can affect the whole business. A manual POS Inventory System can affect the whole business process in terms of sales and confidential document security because a manual process is not reliable enough. " +
                      "Canteen POS System is a computer based way of checking and auditing of the sales of the company, it is faster and more reliable rather than doing manually. The system can lessen errors in editing and can be easily accessed ant time by the company. POS software records each sale when it happens, so your inventory records are always up-to-date." +
                      " Better still, you get much more information about the sale than you could gather with a manual system. By running reports based on this information, you can make better decisions about ordering and merchandising.",
                      IsPublished = true,
                      Title = "Canteen Point of Sale System",
                  }

                );

                //Researches 2 
                this._context.Researches.Add(
                  new Research()
                  {
                      Id = Guid.Parse("ce8dc273-410a-4d4a-9651-3ea1bc704564"),
                      Content = " <h4> A Capstone Project By: Aira Jane K. Garcia and Gellie P. Torio - BSIS</h4>" +
                      " Advances in technology over the years play a huge part in event planning." +
                      " It has undergone a remarkable evolution since the 90s. While it customary to reminisce the past, in reality, event planning today is much more efficient, reliable, flexible, and exciting than it ever has been." +
                      " This study will address ways on how planning an event now differs from before. Using an application or software in planning changed a lot, back in the day everything is handwritten but now you can do it digitally which is more efficient and not time-consuming." +
                      " Finding a place where to hold the event also changes, in the past there are no online maps to look for a suitable venue but now there are several apps to choose from." +
                      " Accomplishing tasks is much easier also now; reminders can be set in the software or the app so every task in the to-do list will be checked. Substantially, advancement in technology helps us in many ways and this study will focus on some of those: the use of software in event planning, budgeting and management of task. " +
                      "This study will provide evidence on how easy, uncomplicated, helpful and useful planning software or application is nowadays.",
                      IsPublished = true,
                      Title = "Event Planner with Budgeting and Task Management System",
                  }

                );

                //Researches 3 
                this._context.Researches.Add(
                  new Research()
                  {
                      Id = Guid.Parse("8bccece7-5574-401f-94a7-c59a80b31412"),
                      Content = "<h4>A System Analysis Development- Capstone Project<hr>" +
                      "Project By: Rachelle M. Macaspac, Geralyn Salenga, Mary Grace Maquesa and Harold Cabalbag- BSBA</h4>" +
                      " Bank industry is widely recognized in the market. It became a huge part of human race." +
                      "This study inspires its readers to take a closer look on banking world." +
                      "In specific, researchers conducted this through researching the bank system of Zambales Rural Bank Inc. The study introduces banking world and states its relevance to the modern world. " +
                      "It covers the background of study, statement of objective (General and Specific), Significance of the study and Scope Limitation. It also includes methodology of study whereby methods were explained as well as the data gathering and output." +
                      "To do so, researcher needed to conduct a background check of the subject. They went to field collecting information through interviewing and observation. " +
                      "By doing that they were able to familiarize themselves with the daily operation of the bank. For example at the end of this study we would to know that inside the bank is divided into departments." +
                      "It has cash, loans and accounting department and that each of these departments use similar system but different access. " +
                      "We would like know why it uses special software and what this software can do, how they maintain it and technical question as such." +
                      "We would like know why it uses special software and what this software can do, how they maintain it and technical question as such.",
                      IsPublished = true,
                      Title = "A study Banking Management System of ZAMBALES RURAL BANK IN LUBAO BRANCH, LUBAO PAMPANGA",
                  }

                );


                //Researches 4 
                this._context.Researches.Add(
                  new Research()
                  {
                      Id = Guid.Parse("e4e569f7-9393-487b-bed7-8e67849a52f6"),
                      Content = "<h4>A System Analysis Development Project By: April Joyce M. Jaraba, Jaymaric V. Mallari and Jelie Rose T. Pineda- BSBA</h4>" +
                      "Points of Sale System is one of the most usable technologies fir the biggest company in the world." +
                      " This system helps you to manage business transaction and loosen you from paperwork's as computation of the day's sale, and keeping the inventory automatically done." +
                      " The design of point of sale will find great value and necessary asset in the company." +
                      " The Personal Collection used this kind of system that helps them to improve their work by inputting data and information about the clients who purchase to them." +
                      " They create this system for delivering some accurate results for computing the daily sales of the company and to know the amount of received items/stocks and quantity of the products." +
                      " In addition, to prevent losing customer because of inaccurate computation. The proponent of this study will discuss the proposal of computerized sale system and the problem that encountered by the employees of PC.",
                      IsPublished = true,
                      Title = "POINTS OF SALE SYSTEM OF PERSONAL COLLECTION",
                  }

                );


                //Researches 5
                this._context.Researches.Add(
                  new Research()
                  {
                      Id = Guid.Parse("f4917e7a-276f-4e84-bb59-781679ab96dc"),
                      Content = "<h4>Capstone Project By: Ryan Christian Soria and Bobby V. Reyes- BSIS</h4>" +
                      "Today, population continually upgrades those results into a growing number of labor especially the Barangay Secretary, Barangay Treasurer, and Barangay Clerk. " +
                      "Summarizing the procedures in the different barangay such as Barangay Del Pilar requiring immediate response to this scenario a possible solution is an efficient and effective Management Information System. " +
                      "The Barangay Record Management System provides an online way of solving the problems faced by the public by saving time. " +
                      "The objectives of the complaints management system is to make complaints easier to coordinate, monitor, track and resolve, and to provide company with an effective tool to identify and target problem areas, monitor complaints handling performance and make business improvements." +
                      "Barangay Record Management System is a management technique foe assessing, analyzing and responding to customer complaints." +
                      "Barangay complaints management software is used to record resolve and respond to customer complaints, request as well as facilitate any other feedback in every barangay. .",
                      IsPublished = true,
                      Title = "The Development of Dinalupihan Bataan Barangay Record Management System",
                  }

                );




                //Researches 6
                this._context.Researches.Add(
                  new Research()
                  {
                      Id = Guid.Parse("e9fba31b-e96b-4949-9801-1bfabff6ccf5"),
                      Content = "<h4>A System Analysis Development Project By: April Anne P. Mabilanga<hr>" +
                      "Trisha G. Dela Rosa and Arisa S. Manalansan- BSBA</h4>" +
                      "This is the study about the inventory system of Fresh Options. It consist of scope and limitations of the system, the flow on how it works, the methods on how system develop," +
                      "the problem that will encounter to the system and other information that related to the system. The inventory system can be entered using a username and password. " +
                      "It is accessible either by supervisor or employee. They can also add data into the database. " +
                      "The system is very user friendly. The system can track or see inventory levels, order, sale, and deliveries. It can be used for making the transaction easily and faster. .",
                      IsPublished = true,
                      Title = "A STUDY ON FRESH OPTIONS INVENTORY SYSTEM OF DINALUPIHAN, BATAAN",
                  }

                );


                //Researches 7
                this._context.Researches.Add(
                  new Research()
                  {
                      Id = Guid.Parse("1c550ef1-a68a-4d21-b721-b7392992062c"),
                      Content = "<h4>Basic Statistic and Thesis Writing By: Kheil M. Salenga, and Dior <hr>" +
                      "Christian G. Datu- BSTM</h4>" +
                      "This study will focus in the effectiveness of NCII tourism training schools in Bataan." +
                      " This study was conducted to know more about the NCII trainings in terms of the Training environment," +
                      " the perception of the students and trainees. And this study also intends the benefits of the program. .",
                      IsPublished = true,
                      Title = "The Effectiveness of NCII Trainings on Selected School in Bataan",
                  }

                );
            }

            //Initialize Achievers
            if (this._context.Achievers.Count() < 1)
            {


                //Achievers 1 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("9eb39581-3102-4e45-b257-a740bf4f5b25"),
                      Content = "LOYALTY AWARDEE",
                      IsPublished = true,
                      Title = "SHAINA DEAN A. TANJI",
                  }

                );




                //Achievers 2
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("8a955b5f-8b7a-4741-81a5-36b136ddbbf9"),
                      Content = "WITH HONORS",
                      IsPublished = true,
                      Title = "JAMIE ANN M. MUNGCAL",
                  }

                );




                //Achievers 3 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("dc2fe60d-80ab-4f29-878d-4f49816edc1f"),
                      Content = "WITH HONORS," +
                      ",HISTORIAN OF THE YEAR" +
                      ",BEST IN PE" +
                      ",DEPORTMENT" +
                      ",PERFECT ATTENDANCE",
                      IsPublished = true,
                      Title = "LALIESCA V. PAGUINTO",
                  }

                );



                //Achievers 4 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("7f7d37d7-3f84-4f97-b360-56c3d1f712f9"),
                      Content = "WITH HONORS" +
                      "COLLABORATIVE LEARNER",
                      IsPublished = true,
                      Title = "GABRIELLE NIÑO D. QUEMADA",
                  }

                );

                //Achievers 5 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("7c6b1cf2-4198-48f7-a229-cef1c692533c"),
                      Content = "WITH HONORS" +
                      "ENGLISH COMMUNICATOR OF THE YEAR" +
                      "FILIPINO COMMUNICATOR OF THE YEAR" +
                      "SCIENTIST OF THE YEAR " +
                      "PRACTICUMER OF THE YEAR" +
                      "PERFORMER OF THE YEAR" +
                      "MATHEMATICIAN OF THE YEAR" +
                      "LEADERSHIP, PERFECT ATTENDANCE",
                      IsPublished = true,
                      Title = "ROSEVI B. TORNO",
                  }

                );

                //Achievers 6 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("9ed88bd8-1335-42ee-ac2d-a39f513b34a1"),
                      Content = "GOLDEN HEART",
                      IsPublished = true,
                      Title = "SITTIE ASHIEA D. ABDUL MOJIEB",
                  }

                );




                //Achievers 7
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("59f116d1-1f37-42db-8700-04040cf4b256"),
                      Content = "WITH HONORS",
                      IsPublished = true,
                      Title = "LEWELL G. DACAYO",
                  }

                );



                //Achievers 8 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("1f25e4b6-47de-4f56-8916-e80b612e11c2"),
                      Content = "WITH HONORS" +
                      "DETERMINED LEARNER",
                      IsPublished = true,
                      Title = "DENIELLE ANNALIESE L. MAGBANUA",
                  }

                );




                //Achievers 9 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("3f9013d5-ab24-47d7-ac27-d9c00d0dccda"),
                      Content = "WITH HONORS,  ENGLISH COMMUNICATOR OF THE YEAR" +
                      "FILIPINO COMMUNICATOR OF THE YEAR" +
                      "SCIENTIST  OF THE YEAR, MATHEMATICIAN  OF THE YEAR" +
                      "HISTORIAN OF THE YEAR, PERFORMER  OF THE YEAR" +
                      "BEST IN PE, RESEARCHER  OF THE YEAR" +
                      "PRACTICUMER  OF THE YEAR",
                      IsPublished = true,
                      Title = "CHRISTINE JOY B. SILVA",
                  }

                );



                //Achievers 10 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("79781dd6-d020-4e15-8710-a17402d1a0e2"),
                      Content = "HAPPY HELPER" +
                      "LITTLE TEACHER" +
                      "MOTIVATOR OF THE YEAR",
                      IsPublished = true,
                      Title = "PRINCESS MARIANNE  CRUZ",
                  }

                );

                

                //Achievers 11 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("c5de8a07-a1a5-4916-9058-d1dacea6001e"),
                      Content = "WITH HONORS" +
                      "PRACTICUMER OF THE YEAR",
                      IsPublished = true,
                      Title = "LEA JOYCE W. ESTONACTOC",
                  }

                );



                //Achievers 12 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("d4ef8c06-3cfd-4d9b-a42f-88b31b916f26"),
                      Content = "OUTSTANDING PUPIL," +
                      "EAGER BEAVER" +
                      "PRUDENT WORKER" +
                      "LITTLE TEACHER",
                      IsPublished = true,
                      Title = "ALYSSA KATE V. AQUINO",
                  }

                );



                //Achievers 13 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("c4399e27-a5d2-4009-8dd4-dd323d97f0e3"),
                      Content = "COURTEOUS LEARNER" +
                      "TENACIOUS STRIVER" +
                      "AMBASSADOR",
                      IsPublished = true,
                      Title = "LUIS MIGUEL L. VITUG",
                  }

                );



                //Achievers 14 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("c59bf4f4-b2ad-487f-aef9-3e3dbb074d28"),
                      Content = "MOST OUTSTANDING PUPIL, BOOKWORM" +
                      "NUMBER SMART, YOUNG STAR (DANCE)" +
                      "YOUNG STAR (SINGING), SPORTY KID" +
                      "NATURE SMART, SELF-SMART, ARTISTIC HANDS" +
                      "MONTESSORI, LITTLE TEACHER" ,
                      IsPublished = true,
                      Title = "KYLE CHRISTIAN D. SILVA",
                  }

                );


                //Achievers 16
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("68878678-eae2-4ecd-a796-a314836eaf7f"),
                      Content = "Loyalty Awardee",
                      IsPublished = true,
                      Title = "Samiale Owen A. De Guzman",
                  }

                );



                //Achievers 17 
                this._context.Achievers.Add(
                  new Achiever()
                  {
                      Id = Guid.Parse("33405c01-1481-42ff-8e99-0b53122d969b"),
                      Content = "With Honors, Loyalty,Sparkler",
                      IsPublished = true,
                      Title = "WU M. BAEK",
                  }

                );

            }

            //Initialize School Events
            if (this._context.SchoolEvents.Count() < 1)
            {


                // School Events 1 
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("fedbab28-fe87-434b-977a-758addd24bc1"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("April 1 2019"),
                      EventEnd = DateTime.Parse("April 5 2019"),
                      IsPublished = true,
                      Title = "Celebration Learning All-Out Preparation & Practices",
                  }

                );


                // School Events 2 
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("65e1df76-5fb4-4aa8-b6b8-dac1681a0c00"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("April 5 2019"),
                      EventEnd = DateTime.Parse("April 5 2019"),
                      IsPublished = true,
                      Title = "Last day of Classes for SY 2018-2019",
                  }

                );




                // School Events 3
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("fe34d554-cb15-4c7e-8315-30844ba30e7e"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("April 8 2019"),
                      EventEnd = DateTime.Parse("April 8 2019"),
                      IsPublished = true,
                      Title = "2019 Eucharistic Celebration",
                  }

                );




                // School Events 4
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("ea5e9963-4e4a-4f64-9fd9-ba25749dbe39"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("April 9 2019"),
                      EventEnd = DateTime.Parse("April 9 2019"),
                      IsPublished = true,
                      Title = "2019 Recognition Rites (Undergraduates)",
                  }

                );


                // School Events 5
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("ae0366c5-05ab-468d-8488-f9c0ec5ea0f2"),
                      Content = "-SHS Recognition Rites",
                      Description = "Other Event..",
                      EventStart = DateTime.Parse("April 11 2019"),
                      EventEnd = DateTime.Parse("April 11 2019"),
                      IsPublished = true,
                      Title = "Dinalupihan Campus Casa & Grade School Graduation & Recognition Rites",
                  }

                );

                // School Events 6
                this._context.SchoolEvents.Add(
                 new SchoolEvent()
                 {
                     Id = Guid.Parse("0e0d243f-0853-4b03-8b24-b297cc334272"),
                     Content = "-Grade 10 Completion Day",
                     Description = "Other Event...",
                     EventStart = DateTime.Parse("April 12 2019"),
                     EventEnd = DateTime.Parse("April 12 2019"),
                     IsPublished = true,
                     Title = "Lincoln High Campus Graduation & Recognition Rites",
                 }
               );


                // School Events 7
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("9f98f2ec-da95-4607-9027-91b1db3f6223"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("April 12 2019"),
                      EventEnd = DateTime.Parse("April 12 2019"),
                      IsPublished = true,
                      Title = "15th Celebration of Learning",
                  }

                );

                // School Events 8
                this._context.SchoolEvents.Add(
              new SchoolEvent()
              {
                  Id = Guid.Parse("42304740-b81c-4307-8fd3-efe61df336ab"),
                  Content = "-Senior High Recognition Rites",
                  Description = "Other Event...",
                  EventStart = DateTime.Parse("April 15 2019"),
                  EventEnd = DateTime.Parse("April 15 2019"),
                  IsPublished = true,
                  Title = "Senior High School Rites First Wave (ABM & TVL)",
              }
            );


                // School Events 9
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("a0f928c7-7e3c-4191-935e-f9fb07692fb6"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("April 15 2019"),
                      EventEnd = DateTime.Parse("April 15 2019"),
                      IsPublished = true,
                      Title = "Start of Summer/Remedial Classes",
                  }

                );

                // School Events 10
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("383497fe-61ff-4d26-810c-efbf4054490e"),
                      Content = "... ",
                      Description = "...",
                      EventStart = DateTime.Parse("April 16 2019"),
                      EventEnd = DateTime.Parse("April 16 2019"),
                      IsPublished = true,
                      Title = "Senior High School Rites Second Wave (HUMSS & GAS)",
                  }
                );

                // School Events 11
                this._context.SchoolEvents.Add(
                 new SchoolEvent()
                 {
                     Id = Guid.Parse("e25f75cc-ba7e-4801-bc08-c67e68e3115e"),
                     Content = "... ",
                     Description = "...",
                     EventStart = DateTime.Parse("April 17 2019"),
                     EventEnd = DateTime.Parse("April 17 2019"),
                     IsPublished = true,
                     Title = "Higher Education Commercement Rites",
                 }
               );


                // School Events 12
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("bb00ae9c-2da5-47f3-afda-e407ac501e2b"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("April 19 2019"),
                      EventEnd = DateTime.Parse("April 19 2019"),
                      IsPublished = true,
                      Title = "Issuance of Report Cards",
                  }

                );



                // School Events 13
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("bb39a11d-9504-482b-b6c0-71ab89fb6f8e"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("May 1 2019"),
                      EventEnd = DateTime.Parse("May 1 2019"),
                      IsPublished = true,
                      Title = "Labor Day(Regular Holiday)",
                  }

                );


                // School Events 14
                this._context.SchoolEvents.Add(
                  new SchoolEvent()
                  {
                      Id = Guid.Parse("242687ed-786f-46df-bd77-070611f6fb2a"),
                      Content = "...",
                      Description = "...",
                      EventStart = DateTime.Parse("May 27 2019"),
                      EventEnd = DateTime.Parse("May 27 2019"),
                      IsPublished = true,
                      Title = "End of Summer Classes",
                  }

                );


            
            }

            //Initialize Ads
            if (this._context.Ads.Count() < 1)
            {


                // Ads 1 
                this._context.Ads.Add(
                  new Ad()
                  {
                      Id = Guid.Parse("0f4c91e9-cf0c-4313-9f3c-6348d2f78637"),
                      Content = "GRADE ELEVEN & GRADE TWELVE offer Academic Strands" +
                      "ACCOUNTANCY, BUSINESS & MANAGEMENT(ABM)," +
                      "SCIENCE, TECHNOLOGY , ENGINEERING & MATHEMATICS (STEM), " +
                      "HUMANITIES & SOCIAL STUDIES(HUMSS)," +
                      "GENERAL ACADEMIC STRAND (GAS)" +
                      "and TECHNICAL-VOCATIONAL LIVELIHOOD TRACK offer" +
                      "HOME ECONOMICS, " +
                      "FOOD AND BEVERAGE SERVICES NC II, " +
                      " FRONT OFFICE SERVICES NC II, " +
                      "HOUSEKEEPING NC II ," +
                      "INFORMATION & COMMUNICATION TECHNOLOGY , " +
                      "COMPUTER SYSTEMS SERVICING NC II," +
                      "PROGRAMMING(NET TECHNOLOGY) NC II," +
                      "For more INQUIRIES, CALL AND VISIT FOLLOWING ( Telephone No. : (047)633-5531 , SMART : 0923-430-3906/ 0912-091-8401 , Globe : 0915-306-6606 , EMAIL ADDRESS: csm.bataan888@yahoo.com , FB PAGE:  www.facebook.com/csmbataan )",
                      Description =
                      "COLLEGE OF SUBIC MONTESSORI,INC" +
                      " BASIC EDUCATION PROGRAMS <br />" +
                      " MONTESSORI CURRICULUM <br />" +
                      "SENIOR HIGH SCHOOL <br />" +
                      "<h4>GRADE ELEVEN & GRADE TWELVE</h4><br />" +
                      "<h5>ACADEMIC TRACK</h5><br />" +
                      "<p>ACCOUNTANCY, BUSINESS & MANAGEMENT(ABM)<br />" +
                      "SCIENCE, TECHNOLOGY , ENGINEERING & MATHEMATICS (STEM)<br />" +
                      "HUMANITIES & SOCIAL STUDIES(HUMSS)<br />" +
                      "GENERAL ACADEMIC STRAND (GAS)</p>"
                      ,
                      IsPublished = true,
                      Title = "K to 12 CURRICULUM",
                  }

              );


                // Ads 2 
                this._context.Ads.Add(
                  new Ad()
                  {
                      Id = Guid.Parse("42802934-fd23-4aa1-91db-4bed4b4e0fc1"),
                      Content = "CHED PROGRAMS offer courses BS IN BUSINESS ADMINISTRATION , Major in Financial Management, Operations Management, Marketing Management" +
                      "Human Resource Development Management, BS IN CRIMINOLOGY , " +
                      "BS IN TOURISM MANAGEMENT , BS IN INFORMATION SYSTEMS ," +
                      " ASSOCIATE IN COMPUTER TECHNOLOGY. " +
                      "For more INQUIRIES, CALL AND VISIT FOLLOWING ( Telephone No. : (047)633-5531 , SMART : 0923-430-3906/ 0912-091-8401 , Globe : 0915-306-6606 , EMAIL ADDRESS: csm.bataan888@yahoo.com , FB PAGE:  www.facebook.com/csmbataan )",
                      Description =
                      "COLLEGE DEPARTMENT <br />" +
                      "CHED PROGRAMS<br />" +
                      "Bachelor of Science Business Administration <br />" +
                      "1. Major in Financial Management <br />" +
                      "2. Operations Management, Marketing Management <br />" +
                      "3. Human Resource Development Management <br />" +
                      "Bachelor of Science Business IN CRIMINOLOGY <br />" +
                      "Bachelor of Science IN TOURISM MANAGEMENT <br />" +
                      "Bachelor of Science IN Customs Administration <br />" +
                      "Bachelor of Science IN Information Systems <br />" +
                      "ASSOCIATE IN COMPUTER TECHNOLOGY",
                      IsPublished = true,
                      Title = "CHED PROGRAMS",
                  }


                );


                // Ads 3 
                this._context.Ads.Add(
                  new Ad()
                  {
                      Id = Guid.Parse("4909f1f3-46b3-42a4-99df-31962e8672e4"),
                      Content = "COLLEGE DEPARTMENT AND TESDA OFFER : " +
                      "COMPUTER SYSTEMS SERVICING NC II, " +
                      "FOOD & BEVERAGE SERVICES NC II ," +
                      "FRONT OFFICE SERVICES NC II ," +
                      "HOUSEKEEPING NC II ," +
                      "VISUAL GRAPHIC DESIGN NC III (ASSESSMENT CENTER) ," + 
                      "For more INQUIRIES, CALL AND VISIT FOLLOWING(Telephone No. : (047)633 - 5531, SMART: 0923 - 430 - 3906 / 0912 - 091 - 8401, Globe: 0915 - 306 - 6606, EMAIL ADDRESS: csm.bataan888@yahoo.com, FB PAGE: www.facebook.com / csmbataan)",                      
                      Description =
                      "COLLEGE DEPARTMENT <br />" +
                      "TESDA PROGRAMS<br />" +
                      "COMPUTER SYSTEMS SERVICING NC II <br />" +
                      "FOOD & BEVERAGE SERVICES NC II <br />" +
                      "FRONT OFFICE SERVICES NC II <br />" +
                      "HOUSEKEEPING NC II <br />" +
                      "VISUAL GRAPHIC DESIGN NC III (ASSESSMENT CENTER)<br />" +
                      "Bachelo of Science in Customs Administration <br />" +
                      "Bachelor of Science in Information Systems <br />" +
                      "Associate Computer Technology <br />"
                      ,
                      IsPublished = true,
                      Title = "TESDA PROGRAMS",
                  }


                );

                // Ads 4
                this._context.Ads.Add(
                  new Ad()
                  {
                      Id = Guid.Parse("0741fa51-f7a4-4e67-8455-e33b0297d31c"),
                      Content =
                      "Applicant must submit the following requirements upon application : " +
                      "Copy of updated resume , " +
                      "Copy of grades in previous term ," +
                      "Certificate of good moral character , Slots are limited and the screening process is very strict. the office of the AAAH(Academic Affairs and Administration Office)handles all applications for this program.",
                      Description =
                      "Requirements of CHED SCHOLARSHIPS <br />" +
                      "Entrance scholaarship is granted to any incoming College Students"
                      ,
                      IsPublished = true,
                      Title = "Deserved Student Assistant (DSA)",
                  }


                );

                this._context.Ads.Add(
                 new Ad()
                 {
                     Id = Guid.Parse("fe30f7a4-8bf0-4f28-8904-18e82b769dca"),
                     Content = "in short pass NSO",
                     Description = 
                     "Requirements of CHED SCHOLARSHIPS <br>" +
                     "DOCUMENT CHECKLIST" +
                     "NAME                        GR SEC" +
                     "picture1 1 (2x2) 2 (1x1) <br />" +
                     "NSO/PSA BIRTH CERTIFICATE (Photocopy) <br />" +
                     "GOOD MORAL CERTIFICATE <br />" +
                     "FORM 138/CARD <br />" +
                     "FORM 137/TRANSCRIPT OF RECORD <br />" +
                     "DIPLOMA (Photocopy) <br />" +
                     "MEDICAL CERTIFICATE <br />",
                     IsPublished = true,
                     Title = "CHED SCHOLARSHIPS",
                 }


               );

                    this._context.Ads.Add(
                  new Ad()
                  {
                      Id = Guid.Parse("676589c8-a031-40c7-b8e1-1607dd83d094"),
                      Content = "in short pass NSO",
                      Description =
                     "Requirements of TESDA SCHOLARSHIPS <br>" +
                     "DOCUMENT CHECKLIST" +
                     "NAME                        GR SEC" +
                     "picture1 1 (2x2) 2 (1x1) <br />" +
                     "NSO/PSA BIRTH CERTIFICATE (Photocopy) <br />" +
                     "GOOD MORAL CERTIFICATE <br />" +
                     "FORM 138/CARD <br />" +
                     "FORM 137/TRANSCRIPT OF RECORD <br />" +
                     "DIPLOMA (Photocopy) <br />" +
                     "MEDICAL CERTIFICATE <br />"
                      ,
                      IsPublished = true,
                      Title = "TESDA SCHOLARSHIPS",
                  }


                );

                this._context.Ads.Add(
                 new Ad()
                 {
                     Id = Guid.Parse("d890bcdb-a3fa-481d-b11a-2a0451c3630a"),
                     Content = "in short pass NSO",
                     Description =
                     "Requirements of ISKOLAR NG BATAAN <br>" +
                     "DOCUMENT CHECKLIST" +
                     "NAME                        GR SEC" +
                     "picture1 1 (2x2) 2 (1x1) <br />" +
                     "NSO/PSA BIRTH CERTIFICATE (Photocopy) <br />" +
                     "GOOD MORAL CERTIFICATE <br />" +
                     "FORM 138/CARD <br />" +
                     "FORM 137/TRANSCRIPT OF RECORD <br />" +
                     "DIPLOMA (Photocopy) <br />" +
                     "MEDICAL CERTIFICATE <br />"
                     ,
                     IsPublished = true,
                     Title = "ISKOLAR NG BATAAN",
                 }


               );
            }



                this._context.SaveChanges();
                return "OK";
            

        }

    }
}

