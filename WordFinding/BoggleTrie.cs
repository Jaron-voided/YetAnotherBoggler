namespace YetAnotherBoggler.WordFinding;

public class BoggleTrie
{
    private readonly TrieNode _root = new TrieNode();           // the root will always be blank, it has 26 children A-Z

    private TrieNode Root => _root;
    
    public static BoggleTrie Create(IEnumerable<string> words)  // Factory method for creating the Trie
    {
        BoggleTrie trie = new BoggleTrie();

        foreach (string word in words)
            trie.Insert(word);

        return trie;
    }

    public TrieIterator GetIterator()
    {
        var it = TrieIterator.Create(_root);
        return it;
    }

    public void Insert(string word)
    {
        var node = _root;                                       // Start at the root
        word = word.ToUpper();

        foreach (char c in word)
        {
            int index = GetIndex(c);

            if (!node.HasChild(c))                              // Node might already have a child from previous word
                node.AddChild(c);
            
            node = node.Children[index];                        // Moves to the next layer of the trie
        }
        
        node.IsWord = true;                                     // Sets word flag to true at the end of the "char c in word"
    }
    
    internal static int GetIndex(char c)
    {
        return c - 'A';                                         // "A" = 65 in ASCII so this returns a number 0-25 for index
    }

    // I'm having to make this internal for now
    internal class TrieNode
    {
        internal char Letter { get; set; }
        internal bool IsWord { get; set; }  
        internal TrieNode?[] Children { get; set; } = new TrieNode?[26];

        internal static TrieNode Create(char letter)
        {
            var node = new TrieNode();
            node.Letter = letter;
            node.IsWord = false;
            
            return node;
        }

        internal TrieNode AddChild(char c)
        {
            int index = GetIndex(c);
            if (!HasChild(c))
                Children[index] = Create(c);

            return Children[index];
        }

        internal bool HasChild(char c)
        {
            int index = GetIndex(c);
            return Children[index] != null;
        }
        
    }

    public class TrieIterator
    {
        internal Stack<TrieNode> VisitedNodes { get; set; } = new Stack<TrieNode>();
        internal static TrieIterator Create(TrieNode node)
        {
            TrieIterator it = new TrieIterator();
            it.VisitedNodes.Push(node);
            return it;
        }
        
        internal bool Traverse(char c)
        {
            int index = GetIndex(c);

            var currentNode = VisitedNodes.Peek();

            if (currentNode.HasChild(c))
            {
                currentNode = currentNode.Children[index];

                VisitedNodes.Push(currentNode);

                if (c == 'Q' && currentNode.HasChild('U'))
                {
                    currentNode = currentNode.Children[GetIndex('U')];
                    VisitedNodes.Push(currentNode);
                }

                return true;
            }

            return false;
        }
        
        public bool HasChild(char c)
        {
            var currentNode = VisitedNodes.Peek();
            return currentNode.HasChild(c);
        }

        public bool IsWord()
        {
            var currentNode = VisitedNodes.Peek();
            return currentNode.IsWord;
        }
        
        public TrieIterator Clone()
        {
            TrieIterator clone = new TrieIterator();
            clone.VisitedNodes = new Stack<TrieNode>(VisitedNodes.Reverse()); // copy stack with same order
            return clone;
        }

        public void Rewind()
        {
            VisitedNodes.Pop();
        }
    }
}