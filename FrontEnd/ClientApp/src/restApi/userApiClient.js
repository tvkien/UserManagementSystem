async function createUserAsync(user) {
    const request = {
        method: "POST",
        headers: { "content-type": "application/json" },
        body: JSON.stringify(user),
    };

    const response = await fetch("gateway/userApi/api/user", request);
    return await response.json();
}

async function editUserAsync(user) {
    const request = {
        method: "PUT",
        headers: { "content-type": "application/json" },
        body: JSON.stringify(user),
    };

    const response = await fetch("gateway/userApi/api/user/" + user.id, request);
    return await response.json();
}

async function deleteUserAsync(id) {
    const response = await fetch('gateway/userApi/api/user/' + id, {
        method: 'DELETE',
    })

    return await response.json();
}

async function getAllUserAsync() {
    const response = await fetch("gateway/userApi/api/user/get-all-users");
    return await response.json();
}

async function getUsersToExportAsync() {
    const response = await fetch("gateway/userApi/api/user/get-users-to-export");
    return await response.json();
}

export { createUserAsync, getAllUserAsync, getUsersToExportAsync, editUserAsync, deleteUserAsync };