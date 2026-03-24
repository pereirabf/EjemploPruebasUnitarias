namespace ProyectoChat
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class UserLogin
    {
        public string UserId { get; set; }
        public string LastLoginRaw { get; set; } // puede venir como texto
        public int FailedAttempts { get; set; }
        public bool IsLocked { get; set; }
    }

    public class UserStatusResult
    {
        public string UserId { get; set; }
        public bool IsInactive { get; set; }
        public bool ShouldLock { get; set; }
        public string RiskLevel { get; set; }
    }

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }

    public class LoginAnalyzer
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public LoginAnalyzer(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public List<UserStatusResult> AnalyzeUsers(List<UserLogin> users, int inactivityMonths = 1)
        {
            var results = new List<UserStatusResult>();
            var now = _dateTimeProvider.Now;
            var thresholdDate = now.AddMonths(-inactivityMonths);

            foreach (var user in users)
            {
                DateTime parsedDate;
                bool parsedOk = TryParseDate(user.LastLoginRaw, out parsedDate);

                bool isInactive = false;
                bool shouldLock = false;
                string risk = "LOW";

                if (!parsedOk)
                {
                    risk = "UNKNOWN";
                    shouldLock = user.FailedAttempts > 3;
                }
                else
                {
                    isInactive = parsedDate <= thresholdDate;

                    if (user.IsLocked)
                    {
                        risk = "LOCKED";
                    }
                    else if (user.FailedAttempts > 5 && isInactive)
                    {
                        shouldLock = true;
                        risk = "HIGH";
                    }
                    else if (user.FailedAttempts > 2)
                    {
                        risk = "MEDIUM";
                    }

                    if ((now - parsedDate).TotalDays > 365)
                    {
                        risk = "CRITICAL";
                        shouldLock = true;
                    }
                }

                results.Add(new UserStatusResult
                {
                    UserId = user.UserId,
                    IsInactive = isInactive,
                    ShouldLock = shouldLock,
                    RiskLevel = risk
                });
            }

            return results.OrderByDescending(r => r.RiskLevel).ToList();
        }

        private bool TryParseDate(string raw, out DateTime date)
        {
            var formats = new[]
            {
            "MM/dd/yyyy",
            "M/d/yyyy",
            "yyyy-MM-dd",
            "dd/MM/yyyy"
        };

            return DateTime.TryParseExact(raw, formats, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out date);
        }
    }
}
