/*

직관
이 문제는 지정된 초기 위치(rStart, cStart)에서 시작하여 나선형 순서로 그리드의 모든 셀을 방문하는 것을 요구합니다. 이 접근 방식은 달팽이 껍질과 유사한 움직임을 시뮬레이션하고, 방향과 스텝 크기를 동적으로 조정하면서 바깥쪽으로 확장하는 것을 포함합니다.

접근
1. 방향성 이동: 오른쪽, 아래, 왼쪽, 위로 이동하는 네 가지 방향 벡터를 정의합니다. 이러한 벡터는 우리가 나선형으로 바깥쪽으로 나아갈 때 그리드에서 현재 위치를 변경하는 데 도움이 됩니다.
2. 동적 단계 및 방향: 이전 Java 솔루션의 고정 단계 접근 방식과 달리, 여기서는 나선형을 진행하면서 각 방향으로 취하는 단계 수를 점진적으로 늘립니다. 각 방향(오른쪽, 아래, 왼쪽, 위)으로 이동을 완료한 후, 나선형이 올바르게 성장하도록 단계를 조정합니다.
3. 경계 검사: 결과 배열에 위치를 추가하기 전에 그리드 경계 내에 있는지 확인하십시오(0 <= x < 행 및 0 <= y < 열). 이렇게 하면 경계를 벗어난 인덱스에 액세스하는 것을 방지할 수 있습니다.
4. 결과 저장: 배열 result를 사용하여 방문한 위치를 방문한 순서대로 저장합니다. 이 배열은 최종 출력으로 반환됩니다.

복잡성
시간 복잡도:
이 솔루션의 시간 복잡도는 O(행 x 열)입니다. 이는 그리드의 각 셀을 정확히 한 번 방문하기 때문입니다. 루프 내에서 연산에는 상수 시간 검사 및 업데이트(O(1))가 포함되어 전체 복잡도가 그리드의 셀 수에 따라 선형이 됩니다.

공간 복잡도:
결과 배열에 필요한 저장소로 인해 공간 복잡도는 O(행 x 열)이며, 이는 방문한 모든 좌표를 보관합니다. 이 외에도 사용되는 추가 공간은 x, y, 방향, 단계 및 인덱스와 같은 변수에 대해 상수 O(1)입니다.

*/

public class Solution
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        // 방향 벡터: right -> down -> left -> up
        int[][] directions = new int[][]
        {
            new int[] {0, 1},   // Right
            new int[] {1, 0},   // Down
            new int[] {0, -1},  // Left
            new int[] {-1, 0}   // Up
        };

        int totalCells = rows * cols;
        int[][] result = new int[totalCells][];
        int x = rStart, y = cStart;
        int direction = 0; // 오른쪽으로 이동 시작
        int steps = 1; // 현재 방향의 초기 단계
        int index = 0;

        result[index++] = new int[] {x, y};

        while (index < totalCells)
        {
            for (int i = 0; i < 2; i++) // 각 스텝 증가 후 사이클에서 두 번 이동
            {
                for (int j = 0; j < steps; j++)
                {
                    x += directions[direction][0];
                    y += directions[direction][1];

                    if (x >= 0 && x < rows && y >= 0 && y < cols)
                    {
                        result[index++] = new int[] { x, y };
                    }
                }
                direction = (direction + 1) % 4; // 방향 변경
            }
            steps++; // 두 방향 이동 완료 후 단계 증가
        }
        return result;
    }
}