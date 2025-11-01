# Simple PowerShell HTTP Server
$port = 8000
$url = "http://localhost:$port/"

# Create HTTP listener
$listener = New-Object System.Net.HttpListener
$listener.Prefixes.Add($url)
$listener.Start()

Write-Host "Server started at $url"
Write-Host "Serving files from: $(Get-Location)"
Write-Host "Press Ctrl+C to stop the server"

try {
    while ($listener.IsListening) {
        $context = $listener.GetContext()
        $request = $context.Request
        $response = $context.Response
        
        # Get requested file path
        $requestedPath = $request.Url.LocalPath
        if ($requestedPath -eq '/') {
            $requestedPath = '/index.html'
        }
        
        $filePath = Join-Path (Get-Location) $requestedPath.TrimStart('/')
        
        Write-Host "Request: $($request.HttpMethod) $($request.Url.LocalPath)"
        
        if (Test-Path $filePath -PathType Leaf) {
            # File exists, serve it
            $content = Get-Content $filePath -Raw -Encoding UTF8
            $buffer = [System.Text.Encoding]::UTF8.GetBytes($content)
            
            # Set content type
            $extension = [System.IO.Path]::GetExtension($filePath).ToLower()
            switch ($extension) {
                '.html' { $response.ContentType = 'text/html; charset=utf-8' }
                '.css' { $response.ContentType = 'text/css' }
                '.js' { $response.ContentType = 'application/javascript' }
                '.json' { $response.ContentType = 'application/json' }
                default { $response.ContentType = 'text/plain' }
            }
            
            $response.StatusCode = 200
            $response.ContentLength64 = $buffer.Length
            $response.OutputStream.Write($buffer, 0, $buffer.Length)
        } else {
            # File not found
            $notFoundMessage = "404 - File Not Found: $requestedPath"
            $buffer = [System.Text.Encoding]::UTF8.GetBytes($notFoundMessage)
            $response.StatusCode = 404
            $response.ContentLength64 = $buffer.Length
            $response.OutputStream.Write($buffer, 0, $buffer.Length)
        }
        
        $response.OutputStream.Close()
    }
} finally {
    $listener.Stop()
    Write-Host "Server stopped"
}