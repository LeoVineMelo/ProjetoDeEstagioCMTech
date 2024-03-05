namespace ProjetoCMTech.Model
{
    public class Status
    {
       
            public enum StatusEnum
            {

                Offline = 0,
                Disponível = 1,
                Ausente = 2,
                Ocupado = 3


            }
            public int valor { get; set; }
            public Status GetStatus(int valor)
            {
                switch (valor)
                {
                    case 0:
                        return new Status { valor = (int)StatusEnum.Offline };
                    case 1:
                        return new Status { valor = (int)StatusEnum.Disponível };
                    case 2:
                        return new Status { valor = (int)StatusEnum.Ausente };
                    case 3:
                        return new Status { valor = (int)StatusEnum.Ocupado };
                    default:
                        return new Status { valor = (int)StatusEnum.Offline };
                }
            }
        
    }
}
