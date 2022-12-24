using System;

namespace Sokoban
{
    class Program
    {
        // 방향을 위한 열거형 정의
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        static void Main()
        {
            // 초기 세팅
            Console.ResetColor();                               // 컬러를 초기화한다.
            Console.CursorVisible = false;                      // 커서를 숨긴다.
            Console.Title = "My Sokoban";                       // 타이틀을 설정한다.
            Console.BackgroundColor = ConsoleColor.DarkBlue;    // 배경색을 설정한다.
            Console.ForegroundColor = ConsoleColor.Gray;        // 글꼴색을 설정한다.
            Console.Clear();                                    // 콘솔 창에 출력된 내용을 모두 지운다.

            // 기호 상수 정의
            const int CONSOLE_MIN_X = 0;
            const int CONSOLE_MIN_Y = 0;
            const int CONSOLE_MAX_X = 15;
            const int CONSOLE_MAX_Y = 10;

            const int INITIAL_PLAYER_X = 0;
            const int INITIAL_PLAYER_Y = 0;
            const string PLAYER_STRING = "P";

            const int INITIAL_BOX_X = 5;
            const int INITIAL_BOX_Y = 5;
            const string BOX_STRING = "B";

            // 플레이어 위치 좌표
            int playerX = INITIAL_PLAYER_X;
            int playerY = INITIAL_PLAYER_Y;
            Direction playerDirection = Direction.Left;

            // 박스 좌표
            int boxX = INITIAL_BOX_X;
            int boxY = INITIAL_BOX_Y;

            // 게임 루프
            while (true)
            {
                // ======================= Render ==========================
                // 이전 프레임을 지운다.
                Console.Clear();

                // 플레이어를 그려준다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(PLAYER_STRING);

                // 박스를 그려준다.
                Console.SetCursorPosition(boxX, boxY);
                Console.Write(BOX_STRING);

                // ======================= ProcessInput =======================
                ConsoleKeyInfo currentKeyInfo = Console.ReadKey();

                // ======================= Update =======================
                // 플레이어 업데이트
                // 위로 이동
                if (currentKeyInfo.Key == ConsoleKey.UpArrow)
                {
                    playerY = (int)Math.Max(CONSOLE_MIN_Y, playerY - 1);
                    playerDirection = Direction.Up;
                }

                // 아래로 이동
                if (currentKeyInfo.Key == ConsoleKey.DownArrow)
                {
                    playerY = (int)Math.Min(playerY + 1, CONSOLE_MAX_Y);
                    playerDirection = Direction.Down;
                }

                // 왼쪽으로 이동 
                if (currentKeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    playerX = (int)Math.Max(CONSOLE_MIN_X, playerX - 1);
                    playerDirection = Direction.Left;
                }

                // 오른쪽으로 이동 
                if (currentKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    playerX = (int)Math.Min(playerX + 1, CONSOLE_MAX_X);
                    playerDirection = Direction.Right;
                }

                // 박스 업데이트
                if (playerX == boxX && playerY == boxY)
                {
                    switch (playerDirection)
                    {
                        case Direction.Left: // Left
                            if (boxX == CONSOLE_MIN_X)
                            {
                                playerX = CONSOLE_MIN_X + 1;
                            }
                            else
                            {
                                boxX = boxX - 1;
                            }
                            break;
                        case Direction.Right: // Right
                            if (boxX == CONSOLE_MAX_X)
                            {
                                playerX = CONSOLE_MAX_X - 1;
                            }
                            else
                            {
                                boxX = boxX + 1;
                            }
                            break;
                        case Direction.Up: // Up
                            if (boxY == CONSOLE_MIN_Y)
                            {
                                playerY = CONSOLE_MIN_Y + 1;
                            }
                            else
                            {
                                boxY = boxY - 1;
                            }
                            break;
                        case Direction.Down: // Down
                            if (boxY == CONSOLE_MAX_Y)
                            {
                                playerY = CONSOLE_MAX_Y - 1;
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