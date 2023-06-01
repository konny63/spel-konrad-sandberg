using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        //skapa en array (för brädet)
        //med hjälp av 0-9 utan att använda 0 pga spelets karaktärer
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //sätter 1 som standard
        static int choice; //håller vilken ruta såelaren vill markera med sitt täcken
        // "Flag" variaben kollar om den är lika med 1 och då har någon vunnit
        //om det är -1 är det oavgjort och är det 0 är matchen fortfarande igång
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();// när spelet startar igen töms konsolen 
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)//kollar vems tur det är
                {
                    Console.WriteLine("spelare 2s tur");
                }
                else
                {
                    Console.WriteLine("spelare 1s tur");
                }
                Console.WriteLine("\n");
                Board();// Bestämmer funktionen för brädet
                Console.WriteLine("\n");
                Console.WriteLine("välj en ruta att markera tack");
                choice = int.Parse(Console.ReadLine());//läser spelarens val

                // Bestämmer vilken figur som rutan markeras med beroende på vems tur det är
                if (arr[choice] != 'X' && arr[choice] != '@')
                {
                    //om spelare 2s tur markera med @ annars med X
                    if (player % 2 == 0) 
                    {
                        arr[choice] = '@';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                //Om den valda rutan är upptagen visa texten och ladda om brädet utan att byta till nästa spelares tur.
                {
                    Console.WriteLine("Ruta nummer {0} är redan markerad med {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("vänta 2 sekunder medan brädet laddas in igen.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();// nämner funktionen som kollar om nån vunnit
            }
            while (flag != 1 && flag != -1);
            // loop som körs tills någon har vunnit eller att det har blivit oavgjort (brädet är fullt)
            Console.Clear();// töm konsolen
            Board();// fyll brädet med siffror igen
            if (flag == 1)
            // om "Flag" är lika med 1 har någon vunnit
            //alltså personen som markerade en ruta senast har vunnit
            {
                Console.WriteLine("\n");
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else// Om "Flag" är lika med -1 är det oavgjort och ingen har vunnit
            {
                Console.WriteLine("\n");
                Console.WriteLine("Draw");
            }
            Environment.Exit(0); 
        }
        // Bräde metoden som skapar brädet
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
        //Checking that any player has won or not
        private static int CheckWin()
        {
            #region Horisontala vinnande möjliga utfall 
            //vinnande alternativ för första raden
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //vinnande möjliga utfall för andra raden
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //vinnande möjliga utfall för tredje raden
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion
            #region vertikala vinnande möjliga utfall
            //vinnande möjliga utfall för första raden
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //vinnande möjliga utfall för andra raden
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //vinnande möjliga utfall för tredje raden
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonala vinnande möjliga utfall
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            // Om alla rutorna är markerade och ingen har vunnit så är matchen avslutad som oavgjord
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}
