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
        // Do I even need this anymore?
        internal TrieNode _currentNode;
        internal Stack<TrieNode> VisitedNodes { get; set; } = new Stack<TrieNode>();
        internal static TrieIterator Create(TrieNode node)
        {
            TrieIterator it = new TrieIterator();
            it._currentNode = node;
            return it;
        }
        
        internal bool Traverse(char c)
        {
            int index = GetIndex(c);

            if (_currentNode.HasChild(c))
            {
                var nextNode = _currentNode.Children[index];
                _currentNode = nextNode;
                
                VisitedNodes.Push(nextNode);

                if (c == 'Q' && nextNode.HasChild('U'))
                {
                    var uNode = nextNode.Children[GetIndex('U')];
                    _currentNode = uNode;
                    VisitedNodes.Push(_currentNode);
                }

                return true;
            }

            return false;
        }
        
        public bool HasChild(char c)
        {
            return _currentNode.HasChild(c);
        }

        public bool IsWord()
        {
            return _currentNode.IsWord;
        }

        public void Rewind()
        {
            if (VisitedNodes.Count > 0)
            {
                _currentNode = VisitedNodes.Pop();
            }
        }
    }
}