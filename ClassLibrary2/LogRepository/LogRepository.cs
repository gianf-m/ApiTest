using Api.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System;


namespace Api.Logs {
    public class LogRepository : ILogRepository {

        private readonly ApiDbContext galacDbContext;
        public LogRepository(ApiDbContext galacDbContext) {
            this.galacDbContext = galacDbContext;
        }

        public List<Log> GetListLogs() {
            List<Log> Logs = new List<Log>();
                Logs = galacDbContext.Logs.ToList();
            return Logs;
        }
    }
}
