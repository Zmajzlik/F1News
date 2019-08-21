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
                                                            event_id
                                                            ,title
                                                            ,[description]
                                                            ,event_start
                                                            ,event_end
                                                            ,all_day
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
                                eventID = Convert.ToInt32(dr["event_id"]),
                                Subject = Convert.ToString(dr["title"]),
                                Description = Convert.ToString(dr["description"]),
                                Start = Convert.ToString(dr["event_start"]),
                                End = Convert.ToString(dr["event_end"]),
                                IsFullDay = Convert.ToBoolean(dr["all_day"])
                            });
                        }
                    }
                }
            }
            return events;
        }
    }
}
