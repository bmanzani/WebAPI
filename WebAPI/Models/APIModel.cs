using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entity;

namespace WebAPI.Models
{
    public class APIModel
    {
        public static async Task<TableApi> GetValues(int id, SSIS_TESTEContext context)
        {
            var table = await context.TableApi.FindAsync(id);
            return table;
        }

        public static async Task PostValues(TableApi tableApi, SSIS_TESTEContext context)
        {
            context.TableApi.Add(tableApi);
            await context.SaveChangesAsync();
        }

        public static async Task<List<TableApi>> GetAllValues(SSIS_TESTEContext context)
        {
            var table = await context.TableApi.ToAsyncEnumerable().ToList();
            return table;
        }
    }
}
