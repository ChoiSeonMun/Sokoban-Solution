using System;

namespace Sokoban
{
    class Program
    {
        static void Main()
        {
            // 초기 세팅
            Console.ResetColor();                               // 컬러를 초기화한다.
            Console.CursorVisible = false;                      // 커서를 숨긴다.
            Console.Title = "My Sokoban";                       // 타이틀을 설정한다.
            Console.BackgroundColor = ConsoleColor.DarkBlue;    // 배경색을 설정한다.
            Console.ForegroundColor = ConsoleColor.Gray;        // 글꼴색을 설정한다.
            Console.Clear();                                    // 콘솔 창에 출력된 내용을 모두 지운다.

            // 플레이어 위치 좌표
            int playerX = 0;
            int playerY = 0;

            // 게임 루프
            while (true)
            {
                // ======================= Render ==========================
                // 이전 프레임을 지운다.
                Console.Clear();

                // 플레이어를 그려준다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");

                // ======================= ProcessInput =======================
                ConsoleKeyInfo currentKeyInfo = Console.ReadKey();

                // ======================= Update =======================
                // 위로 이동
                if (currentKeyInfo.Key == ConsoleKey.UpArrow)
                {
                    playerY = (int)Math.Max(0, playerY - 1);
                }

                // 아래로 이동
                if (currentKeyInfo.Key == ConsoleKey.DownArrow)  
                {
                    playerY = (int)Math.Min(playerY + 1, 10);
                }

                // 왼쪽으로 이동 
                if (currentKeyInfo.Key == ConsoleKey.LeftArrow) 
                {
                    playerX = (int)Math.Max(0, playerX - 1);
                }

                // 오른쪽으로 이동 
                if (currentKeyInfo.Key == ConsoleKey.RightArrow) 
                {
                    playerX = (int)Math.Min(playerX + 1, 15);
                }
            }
        }
    }
}

