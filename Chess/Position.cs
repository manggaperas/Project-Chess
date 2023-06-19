namespace Chess;

public class Position
{
	private int _column; //buat method getset
	private int _row;
    private int forwardrow;
    private int currentcolumn;

    public Position(int forwardrow, int currentcolumn)
    {
        this.forwardrow = forwardrow;
        this.currentcolumn = currentcolumn;
    }

    // public static int Row { get; private set; }
	// public static int Column { get; private set; } 
}
