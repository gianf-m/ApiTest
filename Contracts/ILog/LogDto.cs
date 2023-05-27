using GalacTest.Enums;

namespace GalacTest.Logs {
    public class LogDto {
        public long Id { get; set; }

        public Acciones Acciones { get; set; }

        public DateTime FechaDeEjecucion { get; set; }

        public string InformacionAdicional { get; set; } = string.Empty;

        public LogDto() {

        }

    }
}
