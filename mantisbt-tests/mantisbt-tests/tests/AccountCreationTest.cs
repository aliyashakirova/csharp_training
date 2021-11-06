using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class AccountCreationTest : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(@"C:\Users\SulimovaA\source\repos\aliyashakirova\csharp_training\mantisbt-tests\mantisbt-tests\config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }
        
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData("testuser", "password", "testuser@localhost.localdomain");
            //{
            //    Name = "testuser",
             //   Password = "password",
             //   Email = "testuser@localhost.localdomain"
            //};

            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
