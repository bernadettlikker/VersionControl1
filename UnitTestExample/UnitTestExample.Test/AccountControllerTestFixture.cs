using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
            ]
       
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            var actualResult = accountController.ValidateEmail(email);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        //"A jelszó legalább 8 karakter hosszú kell legyen, csak az angol ABC betűiből és számokból állhat, és tartalmaznia kell legalább egy kisbetűt, egy nagybetűt és egy számot.
        [Test,
            TestCase("Abc1", false),
            TestCase("abcdabcd", false),
            TestCase("abcdABCD", false),
            TestCase("ABCDABCD", false),
            TestCase("Abc1", false),
            TestCase("Abc1Abc1", true)
            ]

        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            var actualResult = accountController.ValidatePassword(password);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test,
            TestCase("irf@uni-corvinus.hu","Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd1234456")
            ]

        public void TestRedisterHappyPath(string email, string password)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            var actualResult = accountController.Register(email, password);

            //Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }

        [Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "AbcD1234"),
            TestCase("irf@uni-corvinus.hu", "abcD1234"),
            TestCase("irf@uni-corvinus.hu", "ABcD1234")
            ]

        public void TestRegisterValidateException(string email, string password)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
                
            }
            var actualResult = accountController.Register(email, password);

            //Assert
            
        }

    }
}
