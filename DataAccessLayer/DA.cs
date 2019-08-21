using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using F1News.Models;

namespace F1News.DataAccessLayer
{
    public class DA
    {
        public string _ConnectionStrVC { get; set; }

        public DA(string ConnectionStrVC)
        {
            _ConnectionStrVC = ConnectionStrVC;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(_ConnectionStrVC);
            conn.Open();
            return conn;
        }
        private void CloseConnection(SqlConnection conn)
        {
            conn.Close();

        }
        public List<Events> GetCalendarEvents(string start, string end)
        {
            List<Events> events = new List<Events>();

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(@"select
                                                            eventID
                                                            ,Subject
                                                            ,[Description]
                                                            ,Start
                                                            ,End
                                                            ,IsFullday
                                                        from
                                                            [Events]
                                                        where
                                                            event_start between @start and @end", conn)
                {
                    CommandType = CommandType.Text
                })
                {
                    cmd.Parameters.Add("@start", SqlDbType.VarChar).Value = start;
                    cmd.Parameters.Add("@end", SqlDbType.VarChar).Value = end;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            events.Add(new Events()
                            {
                                eventID = Convert.ToInt32(dr["eventID"]),
                                Subject = Convert.ToString(dr["Subject"]),
                                Description = Convert.ToString(dr["Description"]),
                                Start = Convert.ToString(dr["Start"]),
                                End = Convert.ToString(dr["End"]),
                                IsFullDay = Convert.ToBoolean(dr["IsFullDay"])
                            });
                        }
                    }
                }
            }
            return events;
        }
    }
}
