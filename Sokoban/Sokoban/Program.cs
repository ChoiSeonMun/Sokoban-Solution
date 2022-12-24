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
            int playerDirection = 0; // 1 : Left / 2 : Right / 3 : Up / 4 : Down

            // 박스 좌표
            int boxX = 5;
            int boxY = 5;

            // 게임 루프
            while (true)
            {
                // ======================= Render ==========================
                // 이전 프레임을 지운다.
                Console.Clear();

                // 플레이어를 그려준다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");

                // 박스를 그려준다.
                Console.SetCursorPosition(boxX, boxY);
                Console.Write("B");

                // ======================= ProcessInput =======================
                ConsoleKeyInfo currentKeyInfo = Console.ReadKey();

                // ======================= Update =======================
                // 플레이어 업데이트
                // 위로 이동
                if (currentKeyInfo.Key == ConsoleKey.UpArrow)
                {
                    playerY = (int)Math.Max(0, playerY - 1);
                    playerDirection = 3;
                }

                // 아래로 이동
                if (currentKeyInfo.Key == ConsoleKey.DownArrow)  
                {
                    playerY = (int)Math.Min(playerY + 1, 10);
                    playerDirection = 4;
                }

                // 왼쪽으로 이동 
                if (currentKeyInfo.Key == ConsoleKey.LeftArrow) 
                {
                    playerX = (int)Math.Max(0, playerX - 1);
                    playerDirection = 1;
                }

                // 오른쪽으로 이동 
                if (currentKeyInfo.Key == ConsoleKey.RightArrow) 
                {
                    playerX = (int)Math.Min(playerX + 1, 15);
                    playerDirection = 2;
                }

                // 박스 업데이트
                if (playerX == boxX && playerY == boxY)
                {
                    switch (playerDirection)
                    {
                        case 1: // Left
                            if (boxX == 0)
                            {
                                playerX = 1;
                            }
                            else
                            {
                                boxX = boxX - 1;
                            }
                            break;
                        case 2: // Right
                            if (boxX == 15)
                            {
                                playerX = 14;
                            }
                            else
                            {
                                boxX = boxX + 1;
                            }
                            break;
                        case 3: // Up
                            if (boxY == 0)
                            {
                                playerY = 1;
                            }
                            else
                            {
                                boxY = boxY - 1;
                            }
                            break;
                        case 4: // Down
                            if (boxY == 10)
                            {
                                playerY = 9;
                            }
                            else
                            {
                                boxY = boxY + 1;
                            }
                            break;
                        default:
                            Console.WriteLine($"[Error] 플레이어 방향 : {playerDirection}");
                            break;
                    }
                }
            }
        }
    }
}

