using System;

namespace API.Service
{
    public class Util
    {
        public static int CalculaDiffAnos(DateTime dtInicial)
        {
            int anos = DateTime.Now.Year - dtInicial.Year;
            if (DateTime.Now.Month < dtInicial.Month || (DateTime.Now.Month == dtInicial.Month && DateTime.Now.Day < dtInicial.Day))
                anos--;

            return anos;
        }
    }
}
