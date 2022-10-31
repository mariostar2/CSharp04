using System;
using System.Collections;
using System.Collections.Generic;



namespace CSharp04
{
    //굳이 여러개의 객체를 만들필요없이 일반화해서 여러개로 만드는게 가능하다 굳이 class를 여러개 만들 필요가 없다.
    //T : 일반화 자료형.
    //아래의 클래스의 한 데이터를 여러개 담고 있기 위해 만들어져있다.
    // = 클래스 정의 단계에서는 종류가 정해지지 않았다.
    // 매개변수 T를 추가하여 제너릭을 원하는 방식으로 사용하는것이 가능하게 만드는게 가능하다. 
    // 하지만 특정 자료형밖에 담지 못하기 때문에 일반화를 시켜서 어떠한 자료형이라도 대응하는 "가방"을 만드는게 가능하다.
    class Container<T>
    {
        T[] array;
        int index;
        public Container()
        {
            array = new T[10];
            index = 0;

        }
        public T this[int i]
        {
            get
            {
                return array[i];
            }
        }
        
        public void Add(T value)
        {
            array[index++] = value;
        }

    }

    class Item
    {
        public string itemName;
        public int itemPrice;

        //단순한 text가 객채로 변함
        public Item(String itemName,int itemPrice)
        {
            this.itemPrice = itemPrice;
            this.itemName = itemName;
        }

        //가격변경이 가능함 내맘대로(배열추가)
        public override string ToString()
        {
            return $"{itemName}({itemPrice}G)";
        }
    }

    //상인 NPC 
   
    class Npc
    {
        #region
        string name;
        List<Item> itemList;        //Item List 자료형 멤버 변수
        
        public Npc(string name)
        {
            this.name = name;         //자신을 표현하는 함수는 this 
            itemList = new List<Item>();
        }
        
        //아이템 추가기능

        public void AddItem(Item item)
        {
            itemList.Add(item);     //매개변수로 받은 Item 변수를 List에 추가
        }

        //아이템 보여주는 기능
        public void ShowItems()
        {
            Console.WriteLine($"{name}의 상점");
            Console.WriteLine("------------------------");
            for(int i =0; i<itemList.Count; i++) //length가 아닌 Count로 변경 
            {
                Console.WriteLine($"{i + 1}.{itemList[i]}"); 
            }
            Console.WriteLine("------------------------");

        }
    }
#endregion
    internal class Program
    {
        static void MeetNpc(Npc npc)
        {
            Console.WriteLine("가게로 들어감, 상인을 만남");
            npc.ShowItems();
        }
            // 함수:기능
            // 반환형 함수명(매개변수)
            // 자판기에 돈을 넣고 번호를 누르면 물품이 나오게
            
        static Item BuyItem(int gold, int index)
        {
            return new Item("EMPTY", 0);
        }
        static void Main(string[] args)

        {
            BuyItem(9000, 1);
            #region 어레이리스트
            
            //ArrayList
            //=배열을 닮은 컬렉션.
            ArrayList list = new ArrayList(); // new 연산을 통해 인스턴스(객체,클론)을 생성한다.
            list.Add(100);
            list.Add(50.0f);
            list.Add("ABCD");
            list.Add('z');
            

            list.RemoveAt(2); // 뺄수도있고 
            
            list.Insert(1,"INSERT"); //넣을수도 있다

            for (int i = 0; i < list.Count; i++) 
            {
                Console.WriteLine(list[i]);
            }

            //Queue(큐)
            //=선입선출 형태의 자료구조 :데이터가 들어간 순서대로 나온다.(FIFO)
            Queue queue = new Queue();
            queue.Enqueue(100);                 //값을 대입한다(줄을 선다)
            queue.Enqueue(200);

            Console.WriteLine(queue.Dequeue()); //값을 반환한다(줄에서 나온다)
            Console.WriteLine(queue.Dequeue());

            //Stack(스택)
            //== 선입후출 형태의 자료구조. 나중에 들어온 데이터가 먼저 나간다.
            Stack stack = new Stack();
            stack.Push(1000);
            stack.Push(2000);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            
           
            //Hashtable(해쉬 테이블)
            // = Key,Value 한쌍으로 이루어진 자료구조.
            Hashtable table = new Hashtable();
            table.Add("A", 90000);
            table.Add("B", 5000);
            table.Add("C", 100);

            //containskey(object):bool
            // =>키 값이 있는지 확인 후 bool값을 반환하는 함수.
            if (table.ContainsKey("D"))
                Console.WriteLine($"값은:{table["D"]}");
            else
                Console.WriteLine("해당키는 존재하지 않습니다");

            //Hesh값은 변하는 값이다
            //HashTable은 키 값을 고유한 Hashcode로 변환후 index를 찾아낸다.
            //해당 index번째의 배열 방이 값이 들어갈 공간이다.
            String name = "KIM SOP LAOS";
            Console.WriteLine(name.GetHashCode());
            #endregion
            
            #region
            //Generic(일반화)
            //어떠한 일반화 클래스의 내부 자료형은 이때 정해진다.
            //동일한 동작을 자른 자료형 통합해 처리하고 싶을때 사용한다.
            Container<int> intContainer = new Container<int>();
            intContainer.Add(100);

            Container<string> strContainer = new Container<string>();
            strContainer.Add("AABB");

            //Generic type collection.
            //object가 아닌 동일한 자료형을 여러개 담을수 있는 자료구조
            List<int> intList = new List<int>();
            intList.Add(1);
            intList.Add(2);

            //ArrayList ->ArrayList 

            List<string> stringList = new List<string>();
            stringList.Add("ABCD");
            #endregion

            
             
            Npc weaponNpc = new Npc("무기상인");
            weaponNpc.AddItem(new Item("검", 200));
            weaponNpc.AddItem(new Item("대궁", 1500));
            weaponNpc.AddItem(new Item("지팡이",2000));
            
            Npc stuffNpc = new Npc("잡화 상인");
            stuffNpc.AddItem(new Item("강화석B", 200));
            stuffNpc.AddItem(new Item("파란포션", 500));
            stuffNpc.AddItem(new Item("힘강화물약B", 1200));

            
            weaponNpc.ShowItems();
            stuffNpc.ShowItems();
                
            /*
            //데이터생성(배열)
            //이렇게 만들면 제한 없이 만드는게 가능하다.
            List<Item> items = new List<Item>();
            items.Add (new Item("검", 100));
            items.Add (new Item("단검", 200));
            items.Add (new Item("대도", 300));
            items.Add (new Item("소검", 400));
            items.Add (new Item("장도", 500));
            items.Add (new Item("화검", 600));
            items.Add (new Item("소태도", 700));
            */
        }
    
    }
    
}
