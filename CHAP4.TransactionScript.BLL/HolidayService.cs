using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace CHAP4.TransactionScript.BLL
{
    public class HolidayService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["HR"].ConnectionString;
        public static bool BookHolidayFor(int employeeId, DateTime From, DateTime To)
        {
            bool booked = false;
            TimeSpan numberOfDaysRequestedForholiday = To - From;
            if (numberOfDaysRequestedForholiday.Days > 0)
            {
                if (RequestHolidayDoesNotClashWithExistingHoliday(employeeId, From, To))
                {
                    int holidayAvailable = GetHolidayRemainingFor(employeeId);
                    if (holidayAvailable >= numberOfDaysRequestedForholiday.Days)
                    {
                        SumitHolidayBookingFor(employeeId, From, To);
                        booked = true;
                    }
                }
            }
            return booked;
        }

        private static int GetHolidayRemainingFor(int employeeId)
        {
            int dayRemaining = 0;
            return dayRemaining;
        }
        public static List<EmployeeDTO> GetAllEmployeesOnLeaveBetween(DateTime From, DateTime To)
        {
            // ... Example of Transaction Script Method ...
            throw new NotImplementedException();
        }

        public static List<EmployeeDTO> GetAllEmployeesWithHolidayRemaing()
        {
            // ... Example of Transaction Script Method ...
            throw new NotImplementedException();
        }

        private static bool RequestHolidayDoesNotClashWithExistingHoliday(int employeeId, DateTime From, DateTime To)
        {
            return true;
        }

        // Data Access methods

        private static void SumitHolidayBookingFor(int employeeId, DateTime From, DateTime To)
        {
            string insertSql = "INSERT INTO Holidays (EmployeeId, LeaveFrom, LeaveTo) VALUES " +
                               "(@EmployeeId, @LeaveFrom, @LeaveTo);";

            using (SqlConnection connection =
                 new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;

                command.Parameters.Add(new SqlParameter("@EmployeeId", employeeId));
                command.Parameters.Add(new SqlParameter("@LeaveFrom", From));
                command.Parameters.Add(new SqlParameter("@LeaveTo", To));

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static List<BookedLeaveDTO> GetBookedLeaveFor(int employeeId)
        {
            List<BookedLeaveDTO> bookedLeave = new List<BookedLeaveDTO>();

            string selectSql = "SELECT * FROM Holidays WHERE EmployeeId = @EmployeeId;";

            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectSql;
                command.Parameters.Add(new SqlParameter("@EmployeeId", employeeId));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookedLeave.Add(new BookedLeaveDTO
                        {
                            From = DateTime.Parse(reader["LeaveFrom"].ToString()),
                            To = DateTime.Parse(reader["LeaveTo"].ToString()),
                            DaysTaken = ((TimeSpan)(DateTime.Parse(reader["LeaveTo"].ToString()) - DateTime.Parse(reader["LeaveFrom"].ToString()))).Days
                        });
                    }
                }
            }

            return bookedLeave;
        }

        private static int GetHolidayEntitlementFor(int employeeId)
        {
            string selectSql = "SELECT HolidayEntitlement FROM Employees WHERE Id = @EmployeeId;";

            int holidayEntitlement = 0;

            using (SqlConnection connection =
                 new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectSql;

                command.Parameters.Add(new SqlParameter("@EmployeeId", employeeId));

                connection.Open();

                holidayEntitlement = int.Parse(command.ExecuteScalar().ToString());
            }

            return holidayEntitlement;
        }
    }
}
