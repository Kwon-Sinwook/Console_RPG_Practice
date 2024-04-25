- [x] __필수요구사항__
  + ~~게임 시작 화면~~
  + ~~상태 보기~~
  + ~~인벤토리~~
    + ~~장착 관리~~
    + ~~정보 반영 예제~~
  + ~~상점~~
    + ~~아이템 구매~~

`필수 요구 사항 전부 완료`

`sudo code`
```cs
 public class Shop_Item // 상점의 아이템과 정보를 담은 클래스
{
    public List<List<string>> itemList = new List<List<string>>() // 2차원 리스트로 아이템 정보를 저장하는 코드
    {
      //아이템 내용
    };
}

public class Player
{
    // 기본 정보 저장 변수 선언
    // 추가 공격력, 방어력 저장 변수 선언

    public List<List<string>> haveItem = new List<List<string>>(); // 현재 플레이어가 가진 아이템 저장 리스트
    public Shop_Item shop_item = new Shop_Item(); // 상점 아이템을 가져오기 위한 코드

    public void View_rtan() // 상태를 보기 위한 메소드
    {
      ...
    }

    public void View_Inventory() // 인벤토리를 보기 위한 메소드
    {
      ...
    }

    public void Equipment_Management() // 장비 장착을 위한 메소드
    {
      ...
    }

    public void Go_shop() // 상점 이동을 위한 메소드
    {
      ...
    }

    public void Buy_item() // 아이템 구매를 위한 메소
    {
      ...
    }
}


static void Main(string[] args)
{
  Player rtan = new Player(); // Player형 변수 rtan을 선언

  //마을 텍스트 출력 코드

  Console.Write("원하시는 행동을 입력해주세요.\n>> ");
  int input = int.Parse(Console.ReadLine());

  switch (input)
  {
    case 1:
      rtan.View_rtan(); // 상태 보기로 이동
      break;

    case 2:
      rtan.View_Inventory(); // 인벤토리로 이동
      break;

    case 3:
      rtan.Go_shop(); // 상점으로 이동
      break;

    default:
      Console.WriteLine("잘못된 입력입니다.");
      Thread.Sleep(1000);
      break;
  }
}
```

__`급히 작성한 거라 오류가 있을 수 있습니다.`__
