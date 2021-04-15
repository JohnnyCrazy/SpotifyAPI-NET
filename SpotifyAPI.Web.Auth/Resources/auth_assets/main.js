function getUrlParams(hash, start) {
  const hashes = hash.slice(hash.indexOf(start) + 1).split("&");

  if (!hashes || hashes.length === 0 || hashes[0] === "") {
    return undefined;
  }

  const params = {};
  hashes.map((hash) => {
    const [key, val] = hash.split("=");
    params[key] = decodeURIComponent(val);
  });
  return params;
}

function handleImplicitGrant() {
  const params = getUrlParams(window.location.hash, "#");
  if (!params) {
    return;
  }
  params.request_type = "token";

  console.log("Sent request_type token to server", params);
  fetch("?" + new URLSearchParams(params).toString(), {
    method: "POST",
  });
}
handleImplicitGrant();

function handleAuthenticationCode() {
  const params = getUrlParams(window.location.search, "?");
  if (!params) {
    return;
  }
  params.request_type = "code";

  console.log("Sent request_type code to server", params);
  fetch("?" + new URLSearchParams(params).toString(), {
    method: "POST",
  });
}
handleAuthenticationCode();

document.addEventListener("DOMContentLoaded", () => {
  const errorContainer = document.querySelector("#error");
  const successContainer = document.querySelector("#success");
  const params = new URLSearchParams(window.location.search);

  if (params.has("error")) {
    errorContainer.classList.remove("hidden");
  } else {
    successContainer.classList.remove("hidden");
  }
});
