async function getUsernameAsync() {
  const response = await fetch("api/auth/getusername");
  if (response.status == 401) {
    return login();
  }

  return await response.json();
}

function login() {
  window.location.href = "/api/auth/login";
}

function logout() {
  window.location.href = "/api/auth/logout";
}

export { getUsernameAsync, logout };