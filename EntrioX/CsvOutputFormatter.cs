using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace EntrioX
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            return typeof(EventDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<EventDto>).IsAssignableFrom(type) ||
                typeof(TicketDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<TicketDto>).IsAssignableFrom(type) ||
                typeof(ReservationDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<ReservationDto>).IsAssignableFrom(type) ||
                typeof(LocationDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<LocationDto>).IsAssignableFrom(type) ||
                typeof(RewardDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<RewardDto>).IsAssignableFrom(type) ||
                typeof(AppUserDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<AppUserDto>).IsAssignableFrom(type);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<EventDto> events)
            {
                foreach (var e in events)
                    FormatCsv(buffer, e);
            }

            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, EventDto e)
        {
            buffer.AppendLine($"{e.Id},\"{e.Name}\",\"{e.LocationName}\",{e.CreatorId},{e.Capacity}");
        }
    }

}
