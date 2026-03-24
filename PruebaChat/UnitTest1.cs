using ProyectoChat;

namespace PruebaChat
{
    public class UnitTest1
    {

        public class FakeDateTimeProvider : IDateTimeProvider
        {
            public DateTime Now { get; set; }
        }

        [Fact]
        public void AnalizarLogin_Exit0so()
        {
        //datos 
            List<UserLogin> users = new List<UserLogin>();
            //"dd/MM/yyyy HH:mm:ss"
            DateTime dateTime = DateTime.Now;
            string raw = dateTime.ToString();
            UserLogin U = new UserLogin() { UserId = "1", FailedAttempts = 4, IsLocked = false, LastLoginRaw = "12/11/2024" };
            users.Add(U);
            int inactivityMonths = 1;
            IDateTimeProvider dtp = new FakeDateTimeProvider(){ Now = DateTime.Now };
            LoginAnalyzer LA = new LoginAnalyzer(dtp);

            var resultadoEsperado = new List<UserStatusResult>();
            resultadoEsperado.Add(new UserStatusResult
            {
                UserId = U.UserId,
                IsInactive = true,
                ShouldLock = true,
                RiskLevel = "CRITICAL"
            });

            //ejecuci[on
            var resultado = LA.AnalyzeUsers(users, inactivityMonths);

            //comprobaci[on
            Assert.Equal(resultadoEsperado.First().UserId,resultado.First().UserId);
            Assert.Equal(resultadoEsperado.First().IsInactive, resultado.First().IsInactive);
            Assert.Equal(resultadoEsperado.First().ShouldLock, resultado.First().ShouldLock);
            Assert.Equal(resultadoEsperado.First().RiskLevel, resultado.First().RiskLevel);

        }

        [Fact]
        public void ParseoErroneo()
        {
            //datos 
            List<UserLogin> users = new List<UserLogin>();
            //"dd/MM/yyyy HH:mm:ss"
            DateTime dateTime = DateTime.Now;
            string raw = dateTime.ToString();
            UserLogin U = new UserLogin() { UserId = "1", FailedAttempts = 4, IsLocked = false, LastLoginRaw = "13/14/2024" };
            users.Add(U);
            int inactivityMonths = 1;
            IDateTimeProvider dtp = new FakeDateTimeProvider() { Now = DateTime.Now };
            LoginAnalyzer LA = new LoginAnalyzer(dtp);

            var resultadoEsperado = new List<UserStatusResult>();
            resultadoEsperado.Add(new UserStatusResult
            {
                UserId = U.UserId,
                IsInactive = false,
                ShouldLock = true,
                RiskLevel = "UNKNOWN"
            });

            //ejecuci[on
            var resultado = LA.AnalyzeUsers(users, inactivityMonths);

            //comprobaci[on
            Assert.Equal(resultadoEsperado.First().UserId, resultado.First().UserId);
            Assert.Equal(resultadoEsperado.First().IsInactive, resultado.First().IsInactive);
            Assert.Equal(resultadoEsperado.First().ShouldLock, resultado.First().ShouldLock);
            Assert.Equal(resultadoEsperado.First().RiskLevel, resultado.First().RiskLevel);
        }

        [Fact]
        public void EstaBloqueado()
        {
            //datos 
            List<UserLogin> users = new List<UserLogin>();
            //"dd/MM/yyyy HH:mm:ss"
            DateTime dateTime = DateTime.Now;
            string raw = dateTime.ToString();
            UserLogin U = new UserLogin() { UserId = "1", FailedAttempts = 4, IsLocked = true, LastLoginRaw = "4/5/2024" };
            users.Add(U);
            int inactivityMonths = 1;
            IDateTimeProvider dtp = new FakeDateTimeProvider() { Now = DateTime.Now };
            LoginAnalyzer LA = new LoginAnalyzer(dtp);

            var resultadoEsperado = new List<UserStatusResult>();
            resultadoEsperado.Add(new UserStatusResult
            {
                UserId = U.UserId,
                IsInactive = true,
                ShouldLock = true,
                RiskLevel = "CRITICAL"
            });

            //ejecuci[on
            var resultado = LA.AnalyzeUsers(users, inactivityMonths);

            //comprobaci[on
            Assert.Equal(resultadoEsperado.First().UserId, resultado.First().UserId);
            Assert.Equal(resultadoEsperado.First().IsInactive, resultado.First().IsInactive);
            Assert.Equal(resultadoEsperado.First().ShouldLock, resultado.First().ShouldLock);
            Assert.Equal(resultadoEsperado.First().RiskLevel, resultado.First().RiskLevel);
        }

        [Fact]
        public void IntentosFallidosEInactivo()
        {
            //datos 
            List<UserLogin> users = new List<UserLogin>();
            //"dd/MM/yyyy HH:mm:ss"
            DateTime dateTime = DateTime.Now;
            string raw = dateTime.ToString();
            UserLogin U = new UserLogin() { UserId = "1", FailedAttempts = 6, IsLocked = false, LastLoginRaw = "4/5/2024" };
            users.Add(U);
            int inactivityMonths = 1;
            IDateTimeProvider dtp = new FakeDateTimeProvider() { Now = DateTime.Now };
            LoginAnalyzer LA = new LoginAnalyzer(dtp);

            var resultadoEsperado = new List<UserStatusResult>();
            resultadoEsperado.Add(new UserStatusResult
            {
                UserId = U.UserId,
                IsInactive = true,
                ShouldLock = true,
                RiskLevel = "CRITICAL"
            });

            //ejecuci[on
            var resultado = LA.AnalyzeUsers(users, inactivityMonths);

            //comprobaci[on
            Assert.Equal(resultadoEsperado.First().UserId, resultado.First().UserId);
            Assert.Equal(resultadoEsperado.First().IsInactive, resultado.First().IsInactive);
            Assert.Equal(resultadoEsperado.First().ShouldLock, resultado.First().ShouldLock);
            Assert.Equal(resultadoEsperado.First().RiskLevel, resultado.First().RiskLevel);
        }
    }
}
