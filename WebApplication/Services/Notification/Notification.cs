namespace WebApplication.Services
{
    public class Notification
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }


        public static class Defaults
        {
            public static Notification Insert => new Notification { Title = "Sucesso", Message = "Registro Inserido com sucesso!", Type = NotificationType.Success };

            public static Notification Update => new Notification { Title = "Sucesso", Message = "Registro Atualizado com sucesso!", Type = NotificationType.Success };

            public static Notification Delete => new Notification { Title = "Sucesso", Message = "Registro Removido com sucesso!", Type = NotificationType.Success };

            public static Notification NotAllowed => new Notification { Title = "Aviso", Message = "Não Permitido! O livro possui exemplares.", Type = NotificationType.Warning };

            public static Notification Lend => new Notification { Title = "Sucesso", Message = "Livro Emprestado!", Type = NotificationType.Success };

            public static Notification GiveBack => new Notification { Title = "Sucesso", Message = "Livro Devolvido!", Type = NotificationType.Success };

            public static Notification MaximumNumberOfLoans => new Notification { Title = "Aviso", Message = "Empréstimo não Permitido! O Cliente já possui 3 empréstimos em vigência.", Type = NotificationType.Warning };
        }
    }
}
