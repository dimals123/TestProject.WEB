async function GetUsers() {
    const response = await fetch("/api/home", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const employeeTasks = await response.json();
        let rows = document.querySelector("tbody");
        employeeTasks.employeeTasks.forEach(task => {
            rows.append(row(task));
        });
    }
}
async function Create(name, description, employee) {
    const response = await fetch("api/home/create", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            name: name,
            description: description,
            employee: employee
        })
    });
    if (response.ok === true) {
        const task = await response.json();
        reset();
        document.querySelector("tbody").append(row(task));
    }
}

async function Finish(taskId) {
    const response = await fetch("api/home/finish/" + taskId, {
        method: "POST",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        document.querySelector("tr[data-rowid='" + taskId + "']").style.backgroundColor = "green";
        document.querySelector("a[data-id='" + taskId + "']").remove();
    }
}
async function DeleteUser(taskId) {
    const response = await fetch("/api/home/delete/" + taskId, {
        method: "POST",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        document.querySelector("tr[data-rowid='" + taskId + "']").remove();
    }
}

function row(task) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", task.id);

    const id = document.createElement("td");
    id.append(task.id);
    tr.append(id);

    const name = document.createElement("td");
    name.append(task.name);
    tr.append(name);

    const description = document.createElement("td");
    description.append(task.description);
    tr.append(description);

    const employee = document.createElement("td");
    employee.append(task.employee);
    tr.append(employee);
    const links = document.createElement("td");
    if (task.finished == 1) {
        tr.style.backgroundColor = "green";
    }
    else if (task.finished == 0) {
        const finishLink = document.createElement("a");
        finishLink.setAttribute("data-id", task.id);
        finishLink.setAttribute("style", "cursor:pointer;padding:15px;");

        finishLink.append("Выполнить");

        finishLink.addEventListener("click", e => {
            Finish(task.id);
            e.preventDefault();
        });
        links.append(finishLink);
    }
    const removeLink = document.createElement("a");
    removeLink.setAttribute("data-id", task.id);
    removeLink.setAttribute("style", "cursor:pointer;padding:15px;");
    removeLink.append("Удалить");
    removeLink.addEventListener("click", e => {

        e.preventDefault();
        DeleteUser(task.id);
    });

    links.append(removeLink);
    tr.appendChild(links);

    return tr;
}
function reset() {
    const form = document.forms["taskForm"];
    form.reset();
}
function submit() {
    const form = document.forms["taskForm"];
    const name = form.elements["name"].value;
    const description = form.elements["description"].value;
    const employee = form.elements["employee"].value;
    Create(name, description, employee);
}

GetUsers();
