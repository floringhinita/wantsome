namespace xUnit.NetCore.Mocks
{
    using Moq;
    using ProductionCode.MockingExample;
    using Xunit;


    public class LunchNotifierTests
    {
        [Theory]
        [InlineData("2017-01-01 13:00:00", LunchNotifier.LateLunchTemplate)]
        [InlineData("2017-01-01 12:59:59", LunchNotifier.RegularLunchTemplate)]
        public void Test_CorrectTemplateIsUsed_LateLunch_Seam(string currentTime, string expectedTemplate)
        {
            //
            // Create mocks:
            //
            var loggerMock = new Mock<ILogger>();

            var bobMock = new Mock<IEmployee>();
            /*
            * Configure mock so that employee is considered working today and gets notifications via email
            *
            */

            var employeeServiceMock = new Mock<IEmployeeService>();
            /*
            * Configure mock so to return employee from above
            *
            */

            var notificationServiceMock = new Mock<INotificationService>();


            //
            // Create instance of class I'm testing:
            //
            Mock<LunchNotifier_UsingSeam> classUnderTest = null;
            /*
             * Create a partial mock of the LunchNotifier_UsingSeam class and change the GetDateTime() behavior to return DateTime.Parse(currentTime)
             *
             */

            //
            // Run some logic to test:
            //
            classUnderTest.Object.SendLunchtimeNotifications();

            //
            // Check the results:
            //
            notificationServiceMock.Verify(x => x.SendEmail(It.IsAny<IEmployee>(), expectedTemplate));
        }

        [Fact]
        public void Test_EmployeeInOfficeGetsNotified()
        {
            //
            // Create mocks:
            //
            var loggerMock = new Mock<ILogger>();

            var bobMock = new Mock<IEmployee>();
            /*
             * Configure mock so that employee is considered working today and gets notifications via email
             *
             */


            var employeeServiceMock = new Mock<IEmployeeService>();
            /*
             * Configure mock so to return employee from above
             *
             */

            var notificationServiceMock = new Mock<INotificationService>();
            /*
            * Configure mock so that you can verify a notification was sent via email
            *
            */

            //
            // Create instance of class I'm testing:
            //
            var classUnderTest = new LunchNotifier(notificationServiceMock.Object, employeeServiceMock.Object,
                loggerMock.Object);

            //
            // Run some logic to test:
            //
            classUnderTest.SendLunchtimeNotifications();

            //
            // Check the results:
            //

            /*
            * Add verifications to prove emails notification was sent
            *
            */
        }


        [Fact]
        public void Test_ExceptionDoesNotStopNotifications()
        {
            //
            // Create mocks:
            //
            var loggerMock = new Mock<ILogger>();
            /*
            * Configure mock so that you can verify a error was logged
            *
            */

            var bobMock = new Mock<IEmployee>();
            /*
             * Configure mock so that employee is considered working today and gets notifications via email
             *
             */

            var marthaMock = new Mock<IEmployee>();
            /*
             * Configure mock so that employee is considered working today and gets notifications via email
             *
             */


            var employeeServiceMock = new Mock<IEmployeeService>();
            /*
             * Configure mock so to return both employees from above
             *
             */


            var notificationServiceMock = new Mock<INotificationService>();
            /*
             * Configure mock to throw an exception when attempting to send notification via email
             *
             */


            //
            // Create instance of class I'm testing:
            //
            var classUnderTest = new LunchNotifier(notificationServiceMock.Object, employeeServiceMock.Object,
                loggerMock.Object);

            //
            // Run some logic to test:
            //
            classUnderTest.SendLunchtimeNotifications();

            //
            // Check the results:
            //

            /*
             * Add verifications to prove emails notification were attempted twice
             *
             * Add verification that error logger was called
             *
             */
        }
    }
}
