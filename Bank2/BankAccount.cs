using System;

namespace BankAccountNS
{
    /// Класс, представляющий банковский счет с операциями дебета и кредита
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        /// Приватный конструктор для предотвращения создания счета без параметров
        private BankAccount() { }

        /// Инициализирует новый экземпляр класса BankAccount с указанным именем клиента и начальным балансом
        /// <param name="customerName">Имя владельца счета</param>
        /// <param name="balance">Начальный баланс счета</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// Возвращает имя владельца счета
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// Возвращает текущий баланс счета
        public double Balance
        {
            get { return m_balance; }
        }

        /// Снимает указанную сумму со счета
        /// <param name="amount">Сумма для снятия</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Выбрасывается, если сумма снятия превышает баланс или меньше нуля
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount,
                    "Сумма снятия превышает баланс");
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount,
                    "Сумма снятия не может быть отрицательной");
            }

            m_balance -= amount;
        }

        /// Вносит указанную сумму на счет
        /// <param name="amount">Сумма для внесения</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Выбрасывается, если сумма внесения меньше нуля
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount,
                    "Сумма внесения не может быть отрицательной");
            }

            m_balance += amount;
        }

        /// Точка входа в приложение. Демонстрирует работу класса BankAccount
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}