using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;

namespace Taggl.Services.Shifts
{
    public static class ShiftScheduleQueries
    {
        public static IQueryable<ShiftSchedule> WhereCreatedByUser(
            this IQueryable<ShiftSchedule> queryable,
            string userId)
        {
            return queryable.Where(s => s.CreatedById == userId);
        }

        public static IQueryable<ShiftSchedule> WhereIsOnDate(
            this IQueryable<ShiftSchedule> queryable,
            DateTime dateTime)
        {
            return queryable.Where(s =>
                s.FromDate >= dateTime &&
                s.FromDate < dateTime.AddHours(24));
        }

        public static IQueryable<ShiftSchedule> IncludeForResult(
            this IQueryable<ShiftSchedule> queryable)
        {
            return queryable
                .Include(s => s.Gym)
                .Include(s => s.ShiftType)
                .Include(s => s.CreatedBy)
                .Include(s => s.UpdatedBy)
                .Include(s => s.DeletedBy);
        }
    }
}
