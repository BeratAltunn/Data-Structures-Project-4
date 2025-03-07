using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();          
            trie.insert("çanta");
            trie.insert("kitap");
            trie.insert("elma");
            Console.WriteLine(trie.search("armut"));    // Çıktı: False
            Console.WriteLine(trie.search("kitap"));   // Çıktı: True
            Console.WriteLine(trie.search("çanta"));      // Çıktı: True
            Console.WriteLine(trie.search("silgi"));   // Çıktı: False
            Console.WriteLine(trie.search("elma"));      // Çıktı: True   

            /*Trie sınıfı bir Trie veri yapısını temsil eder ve insert metodu ile trie veri yapısına uygun şekilde elemanları ekledikten sonra
             * Search metoduyla belirli kelimenin triede olup olmadığını kontrol ediyoruz.
             * Test aşamasında, örnek kelimeleri Trie'ye ekleyip ardından bu kelimeleri doğru bir şekilde arayarak sonuçları kontrol ediyoruz. */

            //Depth-First-Traverse           
            DijkstraShortestPath dijkstra= new DijkstraShortestPath();
            dijkstra.Main();
            PrimsMinimumSpanningTree prim=new PrimsMinimumSpanningTree();
            prim.Main();
            DepthFirstTraverse depthFirstTraverse = new DepthFirstTraverse();
            depthFirstTraverse.runDFT();
        }
    }
}
