using NUnit.Framework;
using UsweRegistrationUsingLambda;
namespace NUnitTestProject
{
    public class Tests
    {
        UserRegistrationLambdaExpression userRegistration;
        [SetUp]
        public void Setup()
        {
            userRegistration = new UserRegistrationLambdaExpression();
        }

        /// <summary>
        /// TC-1 Throw Custom Exception for Invalid FirstName
        /// </summary>
        [TestCase("Vijay")]//Valid Input
        [TestCase("as")]//Invalid Input- Exception Occured 
        public void GivenFirstNameExpectingThrowCustomException(string firstName)
        {
            string actual = " ";
            try
            {
                actual = userRegistration.FirstNameLambda(firstName);
            }
            catch (UserRegistrationCustomException exception)
            {
                string expected = "FirstName should contains atleast three characters";
                Assert.AreEqual(expected, exception.Message);
            }

        }
        [TestCase("Kshirasagar")]//valid Input
        [TestCase("1a")]//Invalid Input - Exception Occured and handled by custome exception
        public void Given_LastName_Expecting_ThrowCustomException(string lastName)
        {
            string actual = " ";
            try
            {
                actual = userRegistration.LastNameLambda(lastName);
            }
            catch (UserRegistrationCustomException exception)
            {
                string exptected = "LastName should contains atleast three characters";
                Assert.AreEqual(exptected, exception.Message);
            }
        }

        /// <summary>
        /// TC-3 Throw Custom Exception for Invalid MobileNumber
        /// </summary>
        [TestCase("91 9876543210")]//Valid
        [TestCase("asd123")]//Invalid Input
        public void Given_MobileNumber_Expecting_ThrowCustomException(string mobileNumber)
        {
            string actual = " ";
            try
            {
                actual = userRegistration.MobileNumberLambda(mobileNumber);
            }
            catch (UserRegistrationCustomException exception)
            {
                string expected = "MobileNumber should not be empty";
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC-4 Throw Custom Exception for Invalid Password
        /// </summary>
        [TestCase("Abcde1#")]
        [TestCase("")]
        public void Given_Password_Expecting_ThrowCustomException(string password)
        {
            string actual = " ";
            try
            {
                actual = userRegistration.PasswordLambda(password);
            }
            catch (UserRegistrationCustomException exception)
            {
                Assert.AreEqual("Password should not be empty", exception.Message);
            }
        }
        /// <summary>
        /// TC-5 Throw Custom Exception for Invalid Email
        /// </summary>
        [TestCase("abc@yahoo.com")]
        [TestCase("abc-100@yahoo.com,")]
        [TestCase("")]//Invalid email input
        public void Given_Email_Expecting_ThrowCustomException(string email)
        {
            string actual = " ";
            try
            {
                actual = userRegistration.EmailLambda(email);
            }
            catch (UserRegistrationCustomException exception)
            {
                string expected = "Email should not be empty";
                Assert.AreEqual(expected, exception.Message);
            }
        }

    }
}