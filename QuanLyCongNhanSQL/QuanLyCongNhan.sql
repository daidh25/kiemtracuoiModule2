CREATE DATABASE QuanLyCongNhan
CREATE TABLE departments (
    department_id INT PRIMARY KEY IDENTITY(1,1),
    department_name VARCHAR(100) NOT NULL,
    locations VARCHAR(100)
);

CREATE TABLE workers (
    worker_id INT PRIMARY KEY IDENTITY(1,1),
    worker_name VARCHAR(100) NOT NULL,
    date_of_birth DATE,
    gender VARCHAR(10),
    address VARCHAR(200),
    phone_number int,
    position VARCHAR(50),
    hire_date DATE
);

CREATE TABLE worker_department (
    worker_id INT,
    department_id INT,
    assigned_date DATE,
    PRIMARY KEY (worker_id, department_id),
    FOREIGN KEY (worker_id) REFERENCES workers(worker_id),
    FOREIGN KEY (department_id) REFERENCES departments(department_id)
)

CREATE TABLE salaries (
    worker_id INT,
    salary_date DATE,
    basic_salary DECIMAL(10, 2),
    overtime_hours DECIMAL(5, 2),
    overtime_pay DECIMAL(10, 2),
    total_salary DECIMAL(10, 2),
    PRIMARY KEY (worker_id, salary_date),
    FOREIGN KEY (worker_id) REFERENCES workers(worker_id)
)

CREATE TABLE work_schedules (
    schedule_id INT PRIMARY KEY IDENTITY(1,1),
    worker_id INT,
    work_date DATE,
    shifts VARCHAR(20),
    hours_worked DECIMAL(5, 2),
    FOREIGN KEY (worker_id) REFERENCES workers(worker_id)
)


INSERT INTO departments (department_name, locations) VALUES 
(N'May', 'Khu A'),
(N'Cắt', 'Khu B'),
(N'Kiểm tra chất lượng', 'Khu C');


INSERT INTO workers (worker_name, date_of_birth, gender, address, phone_number, position, hire_date) VALUES
(N'Nguyễn Văn A', '1985-04-23', N'Nam', N'123 Đường A, TP.Hà Nội', '0123456789', N'Thợ may', '2010-06-01'),
(N'Trần Thị B', '1990-07-19', N'Nữ', N'456 Đường B, TP.Hà Nội', '0987654321', N'Thợ cắt', '2012-09-15'),
(N'Lê Văn C', '1988-01-10', N'Nam', N'789 Đường C, TP.Hà Nội', '0321654987', N'Kiểm tra chất lượng', '2015-03-20');


INSERT INTO worker_department (worker_id, department_id, assigned_date) VALUES
(1, 1, '2010-06-01'),
(2, 2, '2012-09-15'),
(3, 3, '2015-03-20');


INSERT INTO salaries (worker_id, salary_date, basic_salary, overtime_hours, overtime_pay, total_salary) VALUES
(1, '2024-04-30', 5000000, 10, 500000, 5500000),
(2, '2024-04-30', 4500000, 5, 250000, 4750000),
(3, '2024-04-30', 5500000, 8, 400000, 5900000);


INSERT INTO work_schedules (worker_id, work_date, shifts, hours_worked) VALUES
(1, '2024-04-01', N'Sáng', 8),
(1, '2024-04-02', N'Sáng', 8),
(2, '2024-04-01', N'Chiều', 8),
(3, '2024-04-01', N'Đêm', 8);

SELECT *FROM departments
SELECT *FROM workers
SELECT *FROM  worker_department
SELECT *FROM salaries
SELECT *FROM  work_schedules


