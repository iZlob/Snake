namespace Snake.Models.API
{    
    public class GetFieldDataModel
    {        
        public int FieldWidth => Game.Field.FIELD_WIDTH;
        public int FeildHight => Game.Field.FIELD_HIGHT;

        private int[][] _fieldData;
        public int[][] FieldData => _fieldData;

        public GetFieldDataModel(Game.Game game)
        {
            _fieldData = game.Field.FieldData;
        }
    }
}
