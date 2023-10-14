namespace Snake.Models.API
{
    
    public class GetFieldDataModel
    {
        private int[][] _fieldData;
        public int FieldW => Game.Field.FIELD_W;
        public int FeildH => Game.Field.FIELD_H;
        public int[][] FieldData => _fieldData;

        public GetFieldDataModel(Game.Game game)
        {
            _fieldData = game.Field.FieldData;
        }
    }
}
