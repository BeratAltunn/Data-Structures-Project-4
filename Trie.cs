using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children { get; set; }
        public bool isEndOfWord { get; set; }

        public TrieNode()
        {
            children = new Dictionary<char, TrieNode>();
            isEndOfWord = false;
        }
    }

    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void insert(string word)
        {
            TrieNode current = root;

            foreach (char c in word)
            {
                if (!current.children.ContainsKey(c))
                {
                    current.children[c] = new TrieNode();
                }
                current = current.children[c];
            }
            current.isEndOfWord = true;
        }

        public bool search(string word)
        {
            TrieNode node = searchNode(word);
            return node != null && node.isEndOfWord;
        }

        private TrieNode searchNode(string word)
        {
            TrieNode current = root;

            foreach (char c in word)
            {
                if (current.children.ContainsKey(c))
                {
                    current = current.children[c];
                }
                else
                {
                    return null;
                }
            }

            return current;
        }
    }
}
