namespace RaycastSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // layers
            // 1 = ground
            // 2 = enemy
            // 3 = player
            // 4 = interactable

            // bit flags : 필요한 비트들만 올려서 검출하기 편한 값을 할당할때 사용
            int layerFlags = 1 << 2 | 1 << 4; // interactable enemy
            // 00010100

            // 총을 쐈을때 충돌할수있는 대상을 검출하기위한 검출기
            // 이런것을 BitFlags 에서 검출할때 사용하는것이 Bit Mask
            // 예시로, 총알이 충동할수있는 대상을 ground, enemy 로 정했다면, 충돌 bit mask는 :
            int collisionMask = 1 << 1 | 1 << 2; //위에가 얼굴 여기는 가면
            // 00000110

            // 충돌 대상이 맞음.
            if ((layerFlags & collisionMask) > 0)
            {

            }
            // 충돌할수없는 대상
            else
            {
                return;
            }
            //게임 같이 많을 경우 비트 마스크 사용 중요


            float rayOriginX = 2f; // 선을 쏘는 시작점 X
            float rayOriginY = 3.1f; // 선을 쏘는 시작점 Y
            float rayDirectionY = 0f; // 선을 쏘는 방향 Y //방향 백터
            float rayDirectionX = 1f; // 선을 쏘는 방향 X //방향 백터

            float circleColliderCenterX = 10.2f; // 원충돌체 중심점 X
            float circleColliderCenterY = 5.2f; // 원충돌체 중심점 Y
            float circleColliderRadius = 4f; // 원충돌체 반지름

            // ray 위의 임의의 점 x, y 에 대한 방정식
            // x = rayOriginX + rayDirectionX * t ( 0 <= t)
            // y = rayOriginY + rayDirectionY * t ( 0 <= t)

            // 원의방정식
            // (x - circleColliderCenterX)^2 + (y - circleColliderCenterY)^2 = circleColliderRadius^2 //(x - x1)^2 + (y - y1)^2 = r^2

            // 교차점 연립방정식
            // (rayOriginX + rayDirectionX * t - circleColliderCenterX)^2 + (rayOriginY + rayDirectionY * t - circleColliderCenterY)^2 = circleColliderRadius^2
            // rayOriginX^2 + rayDirectionX^2 * t^2 + circleColliderCenterX^2 + 2 * rayOriginX * rayDirectionX * t - 2 * rayOriginX * circleColliderCenterX * t
            // - 2 * rayOriginX * circelColliderCenterX
            // rayOriginY^2 + rayDirectionY^2 * t^2 + circleColliderCenterY^2 + 2 * rayOriginY * rayDirectionY * t - 2 * rayOriginY * circleColliderCenterY * t
            // - 2 * rayOriginY * circelColliderCenterY
            //t에 대한 2차원방정식, 당연히 코딩 테스트에 나오니깐 할 줄 알아야 한다.
            // = (rayOriginX^2 + rayDirectionX^2 + rayOriginY^2 + rayDirectionY^2) * t^2 +
            //   (2 * rayOriginX * rayDirectionX - 2 * rayDirectionX * circleColliderCenterX + 2 * rayOriginY * rayDirectionY - 2 * rayDirectionY * circleColliderCenterY) * t +
            //   circleColliderCenterX^2 + 2 * rayOriginX * circleColliderCenterX + circleColliderCenterX^2 + 2 * rayOriginY * circleColliderCenterY
            //틀렸다고 함

            //아래 강사님이 gpt 한 거
            // ray 상의 임의의 점 (x, y)
            // x = rayOriginX + rayDirectionX * t
            // y = rayOriginY + rayDirectionY * t

            // 원의 방정식
            // (x - circleColliderCenterX)^2 + (y - circleColliderCenterY)^2 = circleColliderRadius^2

            // 두 식을 대입하면 t에 대한 방정식은:
            // (rayOriginX + rayDirectionX * t - circleColliderCenterX)^2 + (rayOriginY + rayDirectionY * t - circleColliderCenterY)^2 = circleColliderRadius^2

            // 이를 전개하면:
            // (rayDirectionX^2 + rayDirectionY^2) * t^2 +
            // 2 * [rayDirectionX * (rayOriginX - circleColliderCenterX) + rayDirectionY * (rayOriginY - circleColliderCenterY)] * t +
            // [(rayOriginX - circleColliderCenterX)^2 + (rayOriginY - circleColliderCenterY)^2 - circleColliderRadius^2] = 0


            // 교차여부 판단을 위한 판별식 계산
            float a = rayDirectionX * rayDirectionX + rayDirectionY * rayDirectionY;
            float b = 2 * (rayDirectionX * (rayOriginX - circleColliderCenterX) + rayDirectionY * (rayOriginY - circleColliderCenterY));
            float c = (rayOriginX - circleColliderCenterX) * (rayOriginX - circleColliderCenterX) +
                      (rayOriginY - circleColliderCenterY) * (rayOriginY - circleColliderCenterY) -
                      circleColliderRadius * circleColliderRadius;

            float discriminant = b * b - 4 * a * c;

            // 해가 없음 (충돌 안함)
            if (discriminant < 0)
            {
                Console.WriteLine("Miss");
            }
            // 해가 있음
            else
            {
                float sqrtOfDiscriminant = (float)Math.Sqrt(discriminant);
                float t1 = (-b + sqrtOfDiscriminant) / (2f * a);
                float t2 = (-b - sqrtOfDiscriminant) / (2f * a);
                float t = 0;

                if (t1 >= 0 && t2 >= 0)
                {
                    t = Math.Min(t1, t2);
                }
                else if (t1 >= 0)
                {
                    t = t1;
                }
                else if (t2 >= 0)
                {
                    t = t2;
                }
                else
                {
                    Console.WriteLine("Miss");
                    return; // 반환.
                }

                float hitx = rayOriginX + rayDirectionX * t;
                float hity = rayOriginY + rayDirectionY * t;
                Console.WriteLine($"Hit ({hitx}, {hity})");
            }
            //3d는 Z축 추가

            // 조건문 if
            // if 의 조건이 참일 경우에만 구현부 실행.
            //if (조건)
            //{
            //    // 조건1이 참일때 실행할 내용
            //}
            //else if (조건2)
            //{
            //    // 조건1이 거짓이고 조건 2가 참일떄 실행할 내용
            //}
            //else
            //{
            //    // 상위 조건드링 모두 거짓일때 실행할 내용
            //}

        }
    }
}
