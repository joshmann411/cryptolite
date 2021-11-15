export class Account {
    constructor(
        public Email: string,
        public AccountType: string,
        public AccountName: string,
        public CurrentAmount: number,
        public ClientId: number
    ) {}
}
