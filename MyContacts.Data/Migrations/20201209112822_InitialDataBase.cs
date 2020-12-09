using Microsoft.EntityFrameworkCore.Migrations;

namespace MyContacts.Data.Migrations
{
    public partial class InitialDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Contacts
            migrationBuilder
                .Sql(
                    "INSERT INTO Contacts (Firstname, Lastname, Fullname, Adress, Email, Mobile) Values" +
                    "('Florent', 'Kleinclaus', 'Florent Kleinclaus', '8, rue des iris 67640 Fegersheim','kleinclaus.florent@gmail.com','+336 74 35 27 00')"
                );

            migrationBuilder
                .Sql(
                    "INSERT INTO Contacts (Firstname, Lastname, Fullname, Adress, Email, Mobile) Values" +
                    "('Martial', 'Kleinclaus', 'Martial Kleinclaus', '8, rue des ecoles 27693 Sylvains-les-Moulins','martial.kleinclaus@sfr.fr','+336 75 03 39 04')"
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO Contacts (Firstname, Lastname, Fullname, Adress, Email, Mobile) Values" +
                    "('Emmanuel', 'Macron', 'Emmanuel Macron', '1, place de l Elysee 75000 Paris','emmanuel.macron@gmail.com','+336 12 34 56 78')"
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO Contacts (Firstname, Lastname, Fullname, Adress, Email, Mobile) Values" +
                    "('Sebastien', 'Sutterlin', 'Sebastien Sutterlin', '1, rue des pote 68500 Guebwiller','seb.sut@gmail.fr','+336 98 76 54 32')"
                );

            //Skills
            migrationBuilder
                .Sql(
                    "INSERT INTO Skills (Name) Values ('Patience')"
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO Skills (Name) Values ('Management')"
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO Skills (Name) Values ('Eloquence')"
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO Skills (Name) Values ('Cooking')"
                );

            //Expertise
            migrationBuilder
                .Sql(
                    "INSERT INTO Expertises (Name) Values ('Beginner')"
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO Expertises (Name) Values ('Intermediate')"
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO Expertises (Name) Values ('Expert')"
                );

            //ContactSkillExpertise
            migrationBuilder
                .Sql(
                    "INSERT INTO ContactSkillExpertises (ExpertiseId, SkillId, ContactId) Values" +
                    " ((SELECT Id FROM Expertises WHERE Name = 'Beginner'),(SELECT Id FROM Skills WHERE Name = 'Cooking'),(SELECT Id FROM Contacts WHERE Firstname = 'Sebastien') ) "
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO ContactSkillExpertises (ExpertiseId, SkillId, ContactId) Values" +
                    " ((SELECT Id FROM Expertises WHERE Name = 'Beginner'),(SELECT Id FROM Skills WHERE Name = 'Patience'),(SELECT Id FROM Contacts WHERE Firstname = 'Sebastien') ) "
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO ContactSkillExpertises (ExpertiseId, SkillId, ContactId) Values" +
                    " ((SELECT Id FROM Expertises WHERE Name = 'Expert'),(SELECT Id FROM Skills WHERE Name = 'Cooking'),(SELECT Id FROM Contacts WHERE Firstname = 'Florent') ) "
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO ContactSkillExpertises (ExpertiseId, SkillId, ContactId) Values" +
                    " ((SELECT Id FROM Expertises WHERE Name = 'Intermediate'),(SELECT Id FROM Skills WHERE Name = 'Patience'),(SELECT Id FROM Contacts WHERE Firstname = 'Florent') ) "
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO ContactSkillExpertises (ExpertiseId, SkillId, ContactId) Values" +
                    " ((SELECT Id FROM Expertises WHERE Name = 'Intermediate'),(SELECT Id FROM Skills WHERE Name = 'Management'),(SELECT Id FROM Contacts WHERE Firstname = 'Martial') ) "
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO ContactSkillExpertises (ExpertiseId, SkillId, ContactId) Values" +
                    " ((SELECT Id FROM Expertises WHERE Name = 'Intermediate'),(SELECT Id FROM Skills WHERE Name = 'Eloquence'),(SELECT Id FROM Contacts WHERE Firstname = 'Martial') ) "
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO ContactSkillExpertises (ExpertiseId, SkillId, ContactId) Values" +
                    " ((SELECT Id FROM Expertises WHERE Name = 'Expert'),(SELECT Id FROM Skills WHERE Name = 'Eloquence'),(SELECT Id FROM Contacts WHERE Firstname = 'Emmanuel') ) "
                );
            migrationBuilder
                .Sql(
                    "INSERT INTO ContactSkillExpertises (ExpertiseId, SkillId, ContactId) Values" +
                    " ((SELECT Id FROM Expertises WHERE Name = 'Expert'),(SELECT Id FROM Skills WHERE Name = 'Management'),(SELECT Id FROM Contacts WHERE Firstname = 'Emmanuel') ) "
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM ContactSkillExpertises");
            migrationBuilder
                .Sql("DELETE FROM Users");
            migrationBuilder
                .Sql("DELETE FROM Contacts");
            migrationBuilder
                .Sql("DELETE FROM Skills");
            migrationBuilder
                .Sql("DELETE FROM Expertises");
        }
    }
}
