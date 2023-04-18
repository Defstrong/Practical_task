using Practice_Problem.Enums;

namespace Practice_Problem.InformationResult
{
    public sealed class Result<T>
    {
        public string TextError { get; set; }
        public ErrorStatus Error { get; set; }
        public bool IsSuccessfully { get; set; } = false;
        public T Payload { get; set; }

    }
}
