namespace CleanCode.FileManteneinance
{
    using System;
    using System.Threading;
    
    public class ConsoleSpinner
    {
        int processCounter;
        public ConsoleSpinner()
        {
            processCounter = 0;
        }
        public void Turn()
        {
            processCounter++;
            switch (processCounter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        public static void TurnWhile(Thread thread)
        {
            var spin = new ConsoleSpinner();
            while (thread.ThreadState != ThreadState.Stopped)
            {
                spin.Turn();
                Thread.Sleep(50);
            }
        }
    }
}