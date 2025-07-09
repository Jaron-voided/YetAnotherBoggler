namespace YetAnotherBoggler.WordFinding;

public class BoggleTrie
{
    private readonly TrieNode _root = new TrieNode();           // the root will always be blank, it has 26 children A-Z
    //internal TrieNode CurrentNode { get; set; }                 // need to keep up with Current so we can traverse

    internal TrieNode Root => _root;
    /*internal void Traverse(char c, TrieNode currentNode)
    {
        int index = GetIndex(c);

        if (currentNode.HasChild(c))
        {
            currentNode = currentNode.Children[index];          // Traverses to the next layer of the tree
        }
    }*/

    public static BoggleTrie Create(IEnumerable<string> words)  // Factory method for creating the Trie
    {
        BoggleTrie trie = new BoggleTrie();
        //trie.CurrentNode = trie._root;

        foreach (string word in words)
            trie.Insert(word);

        return trie;
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
        
        internal TrieNode? Traverse(char c)
        {
            int index = GetIndex(c);

            if (this.HasChild(c))
            {
                return this.Children[index];          // Traverses to the next layer of the tree
            }

            return null;
        }
    }
}