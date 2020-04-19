using System;

namespace CSharp_Class_9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Az Example.cs-ben levő okokból következik, hogy amikor egy metódusnak átadunk egy objektumot (osztály példányt), akkor az az objektum módosítható, hiszen a metódus az objektumra mutató memóriacímet fogja megkapni
            var exampleClass1 = new ExampleClass(1);
            Console.WriteLine(exampleClass1.example); // 1
            Method1(exampleClass1);
            Console.WriteLine(exampleClass1.example); // 2

            // Továbbá pontosan ezen okok következtében nem módosítható egy struct, ha átadjuk egy metódusnak, hiszen olyankor az érték szerinti átadás miatt a metódus egy másolatát kapja meg a struct-nak
            // Mintha a metódus egy teljesen új struct-ot kapott volna, aminek semmi köze az eredetihez
            var exampleStruct1 = new ExampleStruct(1);
            Console.WriteLine(exampleStruct1.example); // 1
            Method1(exampleStruct1);
            Console.WriteLine(exampleStruct1.example); // 2

            // Mindezek tudatában figyeljünk a struct-ok és class-ok tömbjére!
            var exampleStructs = new ExampleStruct[10];
            exampleStructs[0].example = 2; // Nincs hiba, hiszen a tömb elemei létre vannak hozva (struct nem lehet null)

            var exampleClasses = new ExampleClass[10];
            //exampleClasses[0].example = 2; // Hiba, mivel a tömb összes eleme null (előbb létre kell hozni a tömb elemeit!)

            //--------------------------------------------------

            // Struct-ot vagy class-t használjunk?
            // Sok minden van amit egy class tud, de egy struct nem. Viszont egyelőre maradjunk a jelenlegi tudásunknál!
            // Egy class metódusnak való átadása nagyon gyors, mivel egyetlen memóriacímet (32 vagy 64 bit) kell másolnunk. Egy structnál a struct összes adattagját át kell másolni, ami egy nagyobb struct esetén sokkal lassabb lehet.
            // Tehát alapvetően a struct-okat tisztán adattárolásra szoktunk használni, azaz hogy az összetartozó adatokat összefogjuk egy elembe. Maximum 1-2 tisztán ezeken az adatokon dolgozó metódust + konstruktort teszünk bele.
            // Emellett akkor érdemes megfontolni struct használatát, ha kifejezetten szükségünk van a structok azon tulajdonságára, hogy másolódnak:
            var exampleStruct2 = new ExampleStruct(1);
            var exampleStruct3 = exampleStruct2;
            exampleStruct3.example = 2;
            Console.WriteLine(exampleStruct2.example); // 1, mivel a struct másolódott

            var exampleClass2 = new ExampleClass(1);
            var exampleClass3 = exampleClass2;
            exampleClass3.example = 2;
            Console.WriteLine(exampleClass3.example); // 2, mivel a referencia másolódott át

            // Minden más esetben (99%) class-okat használunk!

            // Fontos megjegyezni, hogy struct-ban is és class-ban is lehet struct és class (lásd Example.cs A, B, C, D)

            //--------------------------------------------------

            // Fontos, hogy az OOP nem a végső programozási módszertan, ami mindennél jobb
            // Az OOP csak egy programozási paradigma (~ szabályrendszer, gondolkodásmód)
            // Számtalan programozási paradigma van. Eddig a strukturált programozási paradigmát követtük.
            // Minden feladathoz megvan a megfelelő programozási paradigma

            // OOP szabályai:
            // Encapsulation - egységbezárás (már láttuk)
            // Inheritance - öröklés
            // Abstraction - absztrakció
            // Polymorphism - polimorfizmus

            //--------------------------------------------------

            // Az osztályaink konstruktoraiban használtuk a this kulcsszót, de pontosan mi is ez a this?
            // Képzeljük el úgy, mintha egy rejtett, privát adattagja lenne az osztályunknak
            // Amikor példányosítjuk az osztályunkat, azaz objektumot hozunk létre, akkor a példányosítás során a this értéke beállítódik a példány memóriacímére
            // Például:
            var exampleClass4 = new ExampleClass(1); // Ezen sor lefutása után az exampleClass4 this adattagja saját magára mutat, azaz az exampleClass4 memóriacímére
            var exampleClass5 = new ExampleClass(2); // Ezen sor lefutása után az exampleClass5 this adattagja saját magára mutat, azaz az exampleClass5 memóriacímére

            // Amikor meghívjuk az objektum egy metódusát és a metódusban használjuk a this-t (a metódus lehet konstruktor is), akkor valójában a this csak az aktuális objektumot jelenti amin a metódust meghívtuk
            // Tehát:
            exampleClass4.Print(); // Ebben a metódusban a this lényegében az exampleClass4, csak látszódnak a privát adattagok is, hiszen az osztályon belül vagyunk (tehát 1-et ír ki)
            exampleClass5.Print(); // Ebben a metódusban a this lényegében az exampleClass5, csak látszódnak a privát adattagok is, hiszen az osztályon belül vagyunk (tehát 2-t ír ki)

            //--------------------------------------------------

            // Egyetlen kulcsszó van amivel már találkoztunk, de nem tudjuk mit jelent
            // A static
            // A Main egy static (statikus) metódus, de mit jelent ez?

            // Eddig azt láttuk, hogy az osztály egy tervrajz, amiben az adattagokat akkor tudjuk használni, amikor már példányosítottuk az osztályt
            // Ugyanez igaz a metódusokra:
            //Console.WriteLine(ExampleClass.example); // Ilyen nincs
            //ExampleClass.Print(); // Ilyen sincs

            // Azt is mondhatnánk, hogy az eddigi adattagok példány szintűek voltak, ha az osztályt és a példányt 1-1 szintnek képzeljük el (osztályszint felül, példányszint alul)
            var exampleClass6 = new ExampleClass(1);
            Console.WriteLine(exampleClass6.example); // Az example adattag példányszintű, hiszen csak egy példányon érem el
            exampleClass6.Print(); // A Print() metódus példányszintű, hiszen csak egy példányon hívhatom meg

            // Mi van akkor, ha nekem nincs szükségem példányra, de mégis szeretnék adattagok elérni vagy metódust hívni?
            // Erre való a static kulcsszó
            // A static azt mondja meg, hogy az adott adattag vagy metódus nem példány, hanem osztályszintű, azaz nincs szükség példányra a használatukhoz
            // Lásd:
            Console.WriteLine(ExampleClass.staticExample); // Nincs példányom. Az adattagot az osztályon értem el!
            ExampleClass.StaticPrint(); // Nincs példányom. A metódust az osztályon hívtam meg!

            // Miért jó a static?
            // Van olyan, hogy nincs szükségem példányra, mert az adat vagy a művelet nem köthető egy adott példányhoz (Math, Console)
            // Van olyan adat vagy művelet, amit kifejezetten az osztályok szintjén tudunk csak értelmezni (pl. egyedi azonosító számlálója)
            // Később látjuk, hogy számos más esetben is hasznos lehet!

            // Fontos!
            // Egy static adattag megvan osztva a példányok között, hisz osztályszintű, nem példányszintű!
            // Példa:
            var objectCounter1 = new ObjectCounterClass();
            var objectCounter2 = new ObjectCounterClass();
            Console.WriteLine(objectCounter1.counter1); // 1
            Console.WriteLine(objectCounter2.counter1); // 1
            Console.WriteLine(ObjectCounterClass.counter2); // 2
        }

        static void Method1(ExampleClass exampleClass)
        {
            exampleClass.example = 2;
        }

        static void Method1(ExampleStruct exampleStruct)
        {
            exampleStruct.example = 2;
        }
    }
}
