public partial class MainPage : ContentPage
{
    private bool[,] buttonStates = new bool[5, 5];
    private Button[,] buttons = new Button[5, 5];
    private Grid boardGrid;

    public MainPage()

    {
        // Inicjalizacja kontenera Grid
        boardGrid = new Grid
        {
            RowDefinitions = {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition()
            },
            ColumnDefinitions = {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
        };
        Content = boardGrid;

        // Inicjalizacja przycisków na planszy
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                buttons[i, j] = new Button
                {
                    Text = $"({i},{j})",
                    BackgroundColor = i == 3 && j == 3 ? Color.Red : Color.Gray, // Przycisk (3,3) jest wciśnięty
                    Command = new Command(() => ToggleButton(i, j))

                };
                Grid.SetRow(buttons[i, j], i);
                Grid.SetColumn(buttons[i, j], j);
                boardGrid.Children.Add(buttons[i, j]);
            }
        }
    }

    private void ToggleButton(int x, int y)
    {
        // Zmiana stanu przycisku
        buttonStates[x, y] = !buttonStates[x, y];
        buttons[x, y].BackgroundColor = buttonStates[x, y] ? Color.Red : Color.Gray;

        // Zmiana koloru przycisków przylegających
        ChangeAdjacentButtonsColor(x, y);
    }

    private void ChangeAdjacentButtonsColor(int x, int y)
    {
        // Zmiana koloru przycisków w górę, dół, lewo i prawo
        if (x > 0) ChangeButtonColor(x - 1, y);
        if (x < 4) ChangeButtonColor(x + 1, y);
        if (y > 0) ChangeButtonColor(x, y - 1);
        if (y < 4) ChangeButtonColor(x, y + 1);
    }

    private void ChangeButtonColor(int x, int y)
    {
        // Zmiana koloru przycisku i jego stanu
        buttonStates[x, y] = !buttonStates[x, y];
        buttons[x, y].BackgroundColor = buttonStates[x, y] ? Color.Red : Color.Gray;
    }
}
 