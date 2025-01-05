using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogApp.BL.Helpers
{
    public static class EmailHelper
    {
        public static async Task SendAsync(HttpRequest request)
        {
            string? value = request.Cookies["basket"];
            if (value == null) return new();
            return JsonSerializer.Deserialize<List<BasketCookieItemVM>>(value) ?? new();
        }
    }
}
