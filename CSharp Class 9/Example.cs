using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp_Class_9
{
    // Egy structnak is lehetnek konstruktorai és metódusai
    // Akkor mi a különbség a kettő között?
    // C#-ban valójában a típusokat két csoportra tudjuk bontani: érték és referencia típusok
    // Érték típus: olyan típusok, amelyből ha létrehozunk egy változót, akkor a változó memóriaterületén a típusnak megfelelő konkrét értéket találjuk
    // Érték típus az összes primitív típus (float, double, bool, int stb.) és a struct-ok, illetve enum-ok
    // Referencia típus: olyan típusok, amelyből ha létrehozunk egy változót, akkor a változó memóriaterületén nem a konkrét értéket, hanem egy memóriacímet találunk, ami az érték memóriában elfoglalt helyére mutat
    // Referencia típus a classok és a stringek
    // Vegyük észre, hogy a referencia típusok pontosat azért lehetnek null-ok, mert olyankor maga a memóriacím nem mutat sehova. Az érték típusok pedig pont azért nem lehetnek null-ok, mert a konkrét értéket tároljuk, aminél a null mint érték nem értelmezhető.
    struct ExampleStruct
    {
        public int example;

        public ExampleStruct(int example)
        {
            this.example = example;
        }

        public void Print()
        {
            Console.WriteLine(this.example);
        }
    }

    class ExampleClass
    {
        public int example;

        public static int staticExample;

        public ExampleClass(int example)
        {
            this.example = example; // Itt azért kell a this, mert különben a fordító azt hinné, hogy a konstruktor paraméteréről beszélünk, miközben én az aktuális objektum example adattagjáról beszélek (a paraméter magasabb prioritást élvez)
        }

        public void Print()
        {
            Console.WriteLine(this.example);
        }

        public static void StaticPrint()
        {
            // Mivel static a metódus, ezért osztályszinten vagyunk
            // Ebből következik, hogy a metódust nem példányon hívtuk meg
            // Ezáltal nincs this
            // Ezáltal nem érjük el a példányszintű adattagokat és metódusokat!
            //Console.WriteLine(this.example); // Nem megy!
            //Print(); // Nem megy!

            // A static dolgokat viszont elérjük
            Console.WriteLine(staticExample); // Megy!
            StaticExampleMethod(); // Megy!
        }

        private static void StaticExampleMethod()
        {

        }

        private void ExampleMethod()
        {
            // Nem static-ból viszont mindent elérünk!
            Console.WriteLine(example);
            Console.WriteLine(staticExample);
            Print();
            StaticPrint();
        }

        private static void StaticExampleMethodWithParameter(ExampleClass exampleClass)
        {
            // Viszont ha van egy példányom paraméterként vagy valamilyen más módon, azon static-ból is elérem a nem static dolgokat!
            Console.WriteLine(exampleClass.example); // Megy!
            exampleClass.Print(); // Megy!

            // Sőt, mivel az osztályon belül vagyunk, ezért a paraméter privát adattagjait és metódusait is elérjük
            exampleClass.ExampleMethod(); // Megy!
        }
    }

    struct A
    {
        private B b; // struct-ban lehet struct
        //private A a; // csak nem azonos típusú

        private C c; // struct-ban lehet class
    }

    struct B
    {

    }

    class C
    {
        private D d; // class-ban lehet class
        private C c; // akár azonos típus is, hisz alapértelmezetten null-ként jön létre

        private A a; // class-ban lehet struct
    }

    class D
    {

    }

    class ObjectCounterClass
    {
        public int counter1 = 0;
        public static int counter2 = 0;

        public ObjectCounterClass()
        {
            counter1++;
            counter2++;
        }
    }
}
