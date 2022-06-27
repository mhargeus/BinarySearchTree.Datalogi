// See https://aka.ms/new-console-template for more information

public interface BST_G<T> where T : IComparable<T>
{
	// Remember: the most efficient tree is a balanced tree. A balanced tree has the same (or as close as possible to) amount of nodes on the left as on the right.

	// Inserts a new value to the tree
	public void Insert(T value);

	// Returns true if an object that is equal to value exists in the tree
	// Uses the IComparable<T> interface. x.CompareTo(y) == 0
	public bool Exists(T value);

	// Returns the number of objects currently in the tree
	public int Count();
}
public class BinarySearchTree<T> : BST_G<T> where T : IComparable<T>
{
	private Node<T>? Root = null;

	public void Insert(T value)
    {
		if (Root == null) { Root = new Node<T>(value); }
		else if( Root.Data.CompareTo(value) > 0)
        {
			if( Root.LeftChild == null)
            {
				Root.LeftChild = new Node<T>(value);
            }
			else if(Root.Data.CompareTo(value) > 0 )
			{
                Insert(value);
            }
            else
            {
				Root.RightChild.Insert(value);
            }
        }
    }
}

public class Node<T>
{
	public T Data { get; set; }
	public Node<T>? LeftChild { get; set; }
	public Node<T>? RightChild { get; set; }

	public Node(T value)
	{
		LeftChild = null;
		RightChild = null;
		Data = value;
	}

	// A balanced tree should be as close as possible to equal amount of nodes on both sides
	// 0 is best, but +1 and -1 is ok.
	public int GetBalance()
	{
		int left = (LeftChild == null) ? 0 : LeftChild.GetBalance() + 1;
		int right = (RightChild == null) ? 0 : RightChild.GetBalance() + 1;
		return right - left;
	}
}