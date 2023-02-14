namespace Todo.Model {

    public class TodoModel {
        public int id { get; set; }

        public string title { get; set; }

        public bool done { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}