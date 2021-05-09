using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Reserve
    {
        private int idReserve;
        private int idRecepcionist;
        private int idnClient;
        private string arrivalDate;
        private string finishDate;
        private string typeRoom;

        public string TypeRoom { get => typeRoom; set => typeRoom = value; }
        public int IdRecepcionist { get => idRecepcionist; set => idRecepcionist = value; }
        public int IdnClient { get => idnClient; set => idnClient = value; }
        public string ArrivalDate { get => arrivalDate; set => arrivalDate = value; }
        public string FinishDate { get => finishDate; set => finishDate = value; }
        public int IdReserve { get => idReserve; set => idReserve = value; }

        public Reserve(int idReserve ,int idRecepcionist, int idnClient, string arrivalDate, string finishDate, string typeRoom)
        {
            IdRecepcionist = idRecepcionist;
            IdnClient = idnClient;
            ArrivalDate = arrivalDate;
            FinishDate = finishDate;
            TypeRoom = typeRoom;
            IdReserve = idReserve;

        }
        public Reserve() { }
    }
}