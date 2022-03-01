namespace diamante_201.Devices {
    class Scanner : Device, IScanner {

        public override void ProcessDoc(string document) {
            Console.WriteLine($"Scanner processing: {document}");
        }

        public string Scan() {
            return "Scanner scan result";
        }
    }
}
